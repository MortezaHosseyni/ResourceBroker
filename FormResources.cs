using ResourceBroker.Enums;
using ResourceBroker.Models;
using ResourceBroker.Repositories;
using ResourceBroker.Utilities;

namespace ResourceBroker
{
    public partial class FormResources : Form
    {
        private readonly IResourceRepository _resource;
        private readonly IServiceRepository _service;
        public required Service Service { get; set; }

        public FormResources(IResourceRepository resource, IServiceRepository service)
        {
            InitializeComponent();

            _resource = resource;
            _service = service;
        }

        private async void FormResources_Load(object sender, EventArgs e)
        {
            Text = @$"Resources | {Service.Name}";

            await LoadResources();
        }

        private async void btn_AddResource_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_Name.Text) ||
                    string.IsNullOrEmpty(cmb_ResourceType.Text))
                {
                    MessageBox.Show(@"Please fill the required fields", @"Fill The Fields!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var resource = new Resource
                {
                    Id = Guid.NewGuid(),
                    Name = txt_Name.Text,
                    Description = txt_Description.Text,
                    Capacity = !string.IsNullOrEmpty(txt_Capacity.Text) ? int.Parse(txt_Capacity.Text) : 0,
                    Type = (ResourceType)cmb_ResourceType.SelectedIndex,
                    ServiceId = Service.Id,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _resource.Add(resource);

                await Logger.Log($"|{resource.Id}| New resource added for |{Service.Name}|");

                ClearFields();

                await LoadResources();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txt_Name.Text = string.Empty;
            txt_Description.Text = string.Empty;
            txt_Capacity.Text = string.Empty;
            cmb_ResourceType.Text = string.Empty;
        }

        private async Task LoadResources()
        {
            try
            {
                dgv_Resources.Rows.Clear();

                var resources = await _resource.FindAsync(r => r.ServiceId == Service.Id);

                foreach (var resource in resources.OrderByDescending(x => x.CreatedAt))
                {
                    var resourceType = resource.Type switch
                    {
                        ResourceType.Cpu => "Cpu",
                        ResourceType.Gpu => "Gpu",
                        ResourceType.Ram => "Ram",
                        ResourceType.Ssd => "Ssd",
                        ResourceType.Hdd => "Hdd",
                        _ => "Unknown"
                    };

                    dgv_Resources.Rows.Add(resource.Id, resource.Name, resource.Description, resourceType, resource.Capacity, resource.ResponseTime, resource.Cost, resource.CreatedAt, resource.ServiceId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@$"Error loading data: {ex.Message}", @"ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_CalculateCriteria_Click(object sender, EventArgs e)
        {
            var selectedResources = dgv_Resources.SelectedRows;
            if (selectedResources.Count <= 0)
            {
                MessageBox.Show(@"Please select one or more resource for calculate criteria.", @"Select resources!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow resource in selectedResources)
            {
                var resourceId = resource.Cells["col_resources_Id"].Value.ToString();
                if (string.IsNullOrEmpty(resourceId)) continue;

                var res = await _resource.FindOneAsync(r =>
                    r!.Id == Guid.Parse(resourceId));
                if (res == null) continue;

                var service = await _service.FindOneAsync(s => s!.Id == res.ServiceId);
                if (service == null) continue;

                var responseTime = CalculateResponseTime(service.Upload, service.Download, service.Bandwidth, res.Capacity);
                var cost = CalculateResourceCost(responseTime, res.Capacity, res.Type);

                res.ResponseTime = Math.Round(responseTime, 2);
                res.Cost = Math.Round(cost, 2);
                res.UpdatedAt = DateTime.Now;

                _resource.Update(res);
            }

            await Task.Delay(800);

            await LoadResources();
        }

        public static double CalculateResponseTime(double upload, double download, double bandwidth, int capacity)
        {
            if (bandwidth <= 0)
            {
                const string errorMessage = @"Bandwidth must be greater than zero.";
                MessageBox.Show(errorMessage, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ArgumentException(errorMessage, nameof(bandwidth));
            }

            var uploadTime = (upload / bandwidth) * capacity;
            var downloadTime = (download / bandwidth) * capacity;
            var responseTime = uploadTime + downloadTime;

            return responseTime;
        }

        public static double CalculateResourceCost(double responseTime, int capacity, ResourceType type)
        {
            if (responseTime < 0)
            {
                const string errorMessage = @"Response time must be non-negative.";
                MessageBox.Show(errorMessage, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ArgumentException(errorMessage, nameof(responseTime));
            }

            if (capacity <= 0)
            {
                const string errorMessage = @"Bandwidth must be greater than zero.";
                MessageBox.Show(errorMessage, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ArgumentException(errorMessage, nameof(responseTime));
            }

            var costFactor = type switch
            {
                ResourceType.Cpu => 0.05, // CPU has higher cost factor
                ResourceType.Gpu => 0.08, // GPU is even more costly
                ResourceType.Ram => 0.03, // RAM has moderate cost factor
                ResourceType.Ssd => 0.04, // SSD is moderately costly
                ResourceType.Hdd => 0.02, // HDD has the lowest cost factor
                _ => throw new ArgumentOutOfRangeException(nameof(type), @"Invalid resource type")
            };

            var resourceCost = responseTime * capacity * costFactor;
            return resourceCost;
        }
    }
}
