using ResourceBroker.Models;

namespace ResourceBroker
{
    public partial class FormMakeRequest : Form
    {
        public required User User;

        public FormMakeRequest()
        {
            InitializeComponent();
        }

        private void FormMakeRequest_Load(object sender, EventArgs e)
        {
            this.Text = @$"Make Request | {User.FirstName} {User.LastName}";
        }
    }
}
