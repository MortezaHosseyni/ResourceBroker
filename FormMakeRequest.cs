using ResourceBroker.Enums;
using ResourceBroker.Models;
using ResourceBroker.Repositories;

namespace ResourceBroker
{
    public partial class FormMakeRequest : Form
    {
        public required User User;
        private readonly IRequestRepository _request;
        private readonly IResourceRepository _resource;

        public FormMakeRequest(IRequestRepository request, IResourceRepository resource)
        {
            InitializeComponent();

            _request = request;
            _resource = resource;
        }

        private async void FormMakeRequest_Load(object sender, EventArgs e)
        {
            Text = @$"Make Request | {User.FirstName} {User.LastName}";

            await LoadResources();
        }

        private async Task LoadResources()
        {
            try
            {
                var cpus = await _resource.FindIncludeAsync(r => r.Type == ResourceType.Cpu && !r.IsAllocated, x => x.Service!);
                var gpus = await _resource.FindIncludeAsync(r => r.Type == ResourceType.Gpu && !r.IsAllocated, x => x.Service!);
                var rams = await _resource.FindIncludeAsync(r => r.Type == ResourceType.Ram && !r.IsAllocated, x => x.Service!);
                var ssds = await _resource.FindIncludeAsync(r => r.Type == ResourceType.Ssd && !r.IsAllocated, x => x.Service!);
                var hdds = await _resource.FindIncludeAsync(r => r.Type == ResourceType.Hdd && !r.IsAllocated, x => x.Service!);

                cmb_Cpu.DataSource = null;
                cmb_Cpu.DataSource = cpus;
                cmb_Cpu.DisplayMember = "WithServiceName";
                cmb_Cpu.ValueMember = "Id";

                cmb_Gpu.DataSource = null;
                cmb_Gpu.DataSource = gpus;
                cmb_Gpu.DisplayMember = "WithServiceName";
                cmb_Gpu.ValueMember = "Id";

                cmb_Ram.DataSource = null;
                cmb_Ram.DataSource = rams;
                cmb_Ram.DisplayMember = "WithServiceName";
                cmb_Ram.ValueMember = "Id";

                cmb_Ssd.DataSource = null;
                cmb_Ssd.DataSource = ssds;
                cmb_Ssd.DisplayMember = "WithServiceName";
                cmb_Ssd.ValueMember = "Id";

                cmb_Hdd.DataSource = null;
                cmb_Hdd.DataSource = hdds;
                cmb_Hdd.DisplayMember = "WithServiceName";
                cmb_Hdd.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(@$"Error loading data: {ex.Message}", @"ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_Request_Click(object sender, EventArgs e)
        {
            try
            {
                var requestCpu = new Request
                {
                    Id = Guid.NewGuid(),
                    ResourceId = Guid.Parse(cmb_Cpu.SelectedValue.ToString()),
                    UserId = User.Id,
                    Status = RequestStatus.Pending,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _request.Add(requestCpu);

                var requestGpu = new Request
                {
                    Id = Guid.NewGuid(),
                    ResourceId = Guid.Parse(cmb_Gpu.SelectedValue.ToString()),
                    UserId = User.Id,
                    Status = RequestStatus.Pending,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _request.Add(requestGpu);

                var requestRam = new Request
                {
                    Id = Guid.NewGuid(),
                    ResourceId = Guid.Parse(cmb_Ram.SelectedValue.ToString()),
                    UserId = User.Id,
                    Status = RequestStatus.Pending,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _request.Add(requestRam);

                var requestSsd = new Request
                {
                    Id = Guid.NewGuid(),
                    ResourceId = Guid.Parse(cmb_Ssd.SelectedValue.ToString()),
                    UserId = User.Id,
                    Status = RequestStatus.Pending,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _request.Add(requestSsd);

                var requestHdd = new Request
                {
                    Id = Guid.NewGuid(),
                    ResourceId = Guid.Parse(cmb_Ssd.SelectedValue.ToString()),
                    UserId = User.Id,
                    Status = RequestStatus.Pending,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _request.Add(requestHdd);

                MessageBox.Show(@"Request created successfully for this user.", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
