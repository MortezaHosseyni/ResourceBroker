namespace ResourceBroker
{
    public partial class FormServices : Form
    {
        public FormServices()
        {
            InitializeComponent();
        }

        private void btn_ServiceResources_Click(object sender, EventArgs e)
        {
            var frmResources = new FormResources();
            frmResources.Show();
        }
    }
}
