using ResourceBroker.Enums;
using ResourceBroker.Repositories;

namespace ResourceBroker
{
    public partial class FormRequests : Form
    {
        private readonly IRequestRepository _request;

        public FormRequests(IRequestRepository request)
        {
            InitializeComponent();

            _request = request;
        }

        private async void FormRequests_Load(object sender, EventArgs e)
        {
            await LoadRequests();
        }

        private async Task LoadRequests()
        {
            try
            {
                dgv_Requests.Rows.Clear();

                var requests = await _request.GetAllRequests();

                foreach (var request in requests)
                {
                    var requestStatus = request.Status switch
                    {
                        RequestStatus.Pending => "Pending",
                        RequestStatus.Allocated => "Allocated",
                        RequestStatus.Rejected => "Rejected",
                        RequestStatus.SuggestedAnother => "Alternative",
                        _ => "Unknown"
                    };
                    var resourceType = request.Resource!.Type switch
                    {
                        ResourceType.Cpu => "Cpu",
                        ResourceType.Gpu => "Gpu",
                        ResourceType.Ram => "Ram",
                        ResourceType.Ssd => "Ssd",
                        ResourceType.Hdd => "Hdd",
                        _ => "Unknown"
                    };

                    dgv_Requests.Rows.Add(request.Id, $"{request.User!.FirstName} {request.User.LastName}", requestStatus, $"{request.Resource.Name} ({request.Resource.Service!.Name}) ({resourceType})", request.CreatedAt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@$"Error loading data: {ex.Message}", @"ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
