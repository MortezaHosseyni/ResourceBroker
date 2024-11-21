namespace ResourceBroker
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btn_Users_Click(object sender, EventArgs e)
        {
            var frmUsers = new FormUsers();
            frmUsers.Show();
        }

        private void btn_Services_Click(object sender, EventArgs e)
        {
            var frmServices = new FormServices();
            frmServices.Show();
        }

        private void btn_Requests_Click(object sender, EventArgs e)
        {
            var frmRequests = new FormRequests();
            frmRequests.Show();
        }

        private void btn_Allocations_Click(object sender, EventArgs e)
        {
            var frmAllocations = new FormAllocations();
            frmAllocations.Show();
        }
    }
}
