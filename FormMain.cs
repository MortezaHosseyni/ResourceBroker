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
    }
}
