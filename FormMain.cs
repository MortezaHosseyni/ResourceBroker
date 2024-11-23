using Microsoft.Extensions.DependencyInjection;

namespace ResourceBroker
{
    public partial class FormMain : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public FormMain(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
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
    }
}
