using Microsoft.Extensions.DependencyInjection;
using ResourceBroker.Models;
using ResourceBroker.Repositories;
using ResourceBroker.Utilities;

namespace ResourceBroker
{
    public partial class FormUsers : Form
    {
        private readonly IUserRepository _user;
        private readonly IServiceProvider _serviceProvider;

        public FormUsers(IUserRepository user, IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _user = user;
            _serviceProvider = serviceProvider;
        }

        private async void FormUsers_Load(object sender, EventArgs e)
        {
            await LoadUsers();
        }

        private async void btn_RegisterUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_FirstName.Text) ||
                    string.IsNullOrEmpty(txt_LastName.Text) ||
                    string.IsNullOrEmpty(txt_Email.Text) ||
                    string.IsNullOrEmpty(txt_Phone.Text))
                {
                    MessageBox.Show(@"Please fill the required fields", @"Fill The Fields!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var user = new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = txt_FirstName.Text,
                    LastName = txt_LastName.Text,
                    Email = txt_Email.Text,
                    PhoneNumber = txt_Phone.Text,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _user.Add(user);

                await Logger.Log($"|{user.Id}| New user registered.");

                ClearFields();

                await LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadUsers()
        {
            try
            {
                dgv_Users.Rows.Clear();

                var users = await _user.GetAllIncludeAsync(x => x.Requests, x => x.Allocates);

                foreach (var user in users)
                {
                    dgv_Users.Rows.Add(user.Id, user.FirstName, user.LastName, user.PhoneNumber, user.Email, user.Requests?.Count, user.Allocates?.Count, user.CreatedAt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@$"Error loading data: {ex.Message}", @"ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txt_FirstName.Text = string.Empty;
            txt_LastName.Text = string.Empty;
            txt_Email.Text = string.Empty;
            txt_Phone.Text = string.Empty;
        }

        private void btn_MakeRequest_Click(object sender, EventArgs e)
        {
            if (dgv_Users.SelectedRows.Count <= 0)
            {
                MessageBox.Show(@"Please select a User.", @"Select User!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgv_Users.SelectedRows[0];

            var selectedUser = new User
            {
                Id = Guid.Parse(selectedRow.Cells["col_users_Id"].Value.ToString()!),
                FirstName = selectedRow.Cells["col_users_FirstName"].Value.ToString()!,
                LastName = selectedRow.Cells["col_users_LastName"].Value.ToString()!,
                PhoneNumber = selectedRow.Cells["col_users_Phone"].Value.ToString()!,
                Email = selectedRow.Cells["col_users_Email"].Value.ToString()!
            };

            using var scope = _serviceProvider.CreateScope();

            var form = scope.ServiceProvider.GetRequiredService<FormMakeRequest>();
            form.User = selectedUser;
            form.ShowDialog();
        }
    }
}
