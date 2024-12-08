using Microsoft.Extensions.DependencyInjection;
using ResourceBroker.Logic;
using ResourceBroker.Repositories;

namespace ResourceBroker
{
    public partial class FormMain : Form
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly ResourceAllocator _allocator;
        private readonly IRequestRepository _request;

        public FormMain(IServiceProvider serviceProvider, ResourceAllocator allocator, IRequestRepository request)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _allocator = allocator;
            _request = request;
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            await LoadLogs();

            rtb_MainLogs.SelectionStart = rtb_MainLogs.Text.Length;
            rtb_MainLogs.ScrollToCaret();
        }

        private async void FormMain_Activated(object sender, EventArgs e)
        {
            await LoadLogs();

            rtb_MainLogs.SelectionStart = rtb_MainLogs.Text.Length;
            rtb_MainLogs.ScrollToCaret();
        }

        private async Task LoadLogs()
        {
            rtb_MainLogs.Text = string.Empty;
            rtb_MainLogs.Text = await File.ReadAllTextAsync("mainlogs.txt");
        }

        private void btn_Users_Click(object sender, EventArgs e)
        {
            using var scope = _serviceProvider.CreateScope();

            var form = scope.ServiceProvider.GetRequiredService<FormUsers>();
            form.ShowDialog();
        }

        private void btn_Services_Click(object sender, EventArgs e)
        {
            using var scope = _serviceProvider.CreateScope();

            var form = scope.ServiceProvider.GetRequiredService<FormServices>();
            form.ShowDialog();
        }

        private void btn_Requests_Click(object sender, EventArgs e)
        {
            using var scope = _serviceProvider.CreateScope();

            var form = scope.ServiceProvider.GetRequiredService<FormRequests>();
            form.ShowDialog();
        }

        private void btn_Allocations_Click(object sender, EventArgs e)
        {
            using var scope = _serviceProvider.CreateScope();

            var form = scope.ServiceProvider.GetRequiredService<FormAllocations>();
            form.ShowDialog();
        }

        private void btn_Packages_Click(object sender, EventArgs e)
        {
            using var scope = _serviceProvider.CreateScope();

            var form = scope.ServiceProvider.GetRequiredService<FormPackages>();
            form.ShowDialog();
        }

        private async void btn_Allocate_Click(object sender, EventArgs e)
        {
            var requests = await _request.GetAllPendingRequests();

            foreach (var request in requests)
            {
                await _allocator.AllocateResourceAsync(request);
            }

            await LoadLogs();

            MessageBox.Show(@"All requests has been allocated resource.", @"Resource Allocator!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
