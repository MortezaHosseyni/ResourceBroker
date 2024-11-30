using ResourceBroker.Enums;
using ResourceBroker.Models;
using ResourceBroker.Repositories;
using ResourceBroker.Utilities;

namespace ResourceBroker
{
    public partial class FormResources : Form
    {
        private readonly IResourceRepository _resource;
        public required Service Service { get; set; }

        public FormResources(IResourceRepository resource)
        {
            InitializeComponent();

            _resource = resource;
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

                foreach (var resource in resources)
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

                    dgv_Resources.Rows.Add(resource.Id, resource.Name, resource.Description, resourceType, resource.Capacity, resource.CreatedAt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@$"Error loading data: {ex.Message}", @"ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
