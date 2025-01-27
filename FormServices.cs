﻿using Microsoft.Extensions.DependencyInjection;
using ResourceBroker.Models;
using ResourceBroker.Repositories;
using ResourceBroker.Utilities;

namespace ResourceBroker
{
    public partial class FormServices : Form
    {
        private readonly IServiceRepository _service;
        private readonly IResourceRepository _resource;
        private readonly IServiceProvider _serviceProvider;

        public FormServices(IServiceRepository service, IResourceRepository resource, IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _service = service;
            _resource = resource;
            _serviceProvider = serviceProvider;
        }

        private async void FormServices_Load(object sender, EventArgs e)
        {
            await LoadServices();
        }

        private void btn_ServiceResources_Click(object sender, EventArgs e)
        {
            if (dgv_Services.SelectedRows.Count <= 0)
            {
                MessageBox.Show(@"Please select a Service.", @"Select Service!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgv_Services.SelectedRows[0];

            var selectedService = new Service
            {
                Id = Guid.Parse(selectedRow.Cells["col_services_Id"].Value.ToString()!),
                Name = selectedRow.Cells["col_services_Name"].Value.ToString()!,
                Description = selectedRow.Cells["col_services_Description"].Value.ToString()!,
                Download = float.Parse(selectedRow.Cells["col_services_Download"].Value.ToString()!),
                Upload = float.Parse(selectedRow.Cells["col_services_Upload"].Value.ToString()!),
                Bandwidth = float.Parse(selectedRow.Cells["col_services_Bandwidth"].Value.ToString()!)
            };

            using var scope = _serviceProvider.CreateScope();

            var form = scope.ServiceProvider.GetRequiredService<FormResources>();
            form.Service = selectedService;
            form.ShowDialog();
        }

        private async void btn_AddService_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_Name.Text))
                {
                    MessageBox.Show(@"Please fill the Name field", @"Service Name?!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var service = new Service
                {
                    Id = Guid.NewGuid(),
                    Name = txt_Name.Text,
                    Description = txt_Description.Text,
                    Download = float.Parse(txt_Download.Text),
                    Upload = float.Parse(txt_Upload.Text),
                    Bandwidth = float.Parse(txt_Bandwidth.Text),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _service.Add(service);

                await Logger.Log($"|{service.Id}| New service added.");

                ClearFields();

                await LoadServices();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadServices()
        {
            try
            {
                dgv_Services.Rows.Clear();

                var services = await _service.GetAllAsync();

                foreach (var service in services)
                {
                    var resourcesCount = await _resource.CountAsync(r => r.ServiceId == service.Id);
                    dgv_Services.Rows.Add(service.Id, service.Name, service.Description, service.Download, service.Upload, service.Bandwidth, resourcesCount, service.CreatedAt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@$"Error loading data: {ex.Message}", @"ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txt_Name.Text = string.Empty;
            txt_Description.Text = string.Empty;
            txt_Download.Text = string.Empty;
            txt_Upload.Text = string.Empty;
            txt_Bandwidth.Text = string.Empty;
        }
    }
}
