using ResourceBroker.Repositories;

namespace ResourceBroker
{
    public partial class FormAllocations : Form
    {
        private readonly IAllocateRepository _allocate;

        public FormAllocations(IAllocateRepository allocate)
        {
            InitializeComponent();

            _allocate = allocate;
        }

        private async void FormAllocations_Load(object sender, EventArgs e)
        {
            await LoadAllocations();
        }

        private async Task LoadAllocations()
        {
            try
            {
                dgv_Allocations.Rows.Clear();;

                var allocations = await _allocate.GetAllAllocations();

                foreach (var allocation in allocations)
                {
                    dgv_Allocations.Rows.Add(allocation.Id,
                        $"{allocation.User!.FirstName} {allocation.User.LastName}", $"{allocation.Resource!.Name} ({allocation.Resource.Service!.Name}) ({allocation.Resource.Type})", allocation.CreatedAt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@$"Error loading data: {ex.Message}", @"ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
