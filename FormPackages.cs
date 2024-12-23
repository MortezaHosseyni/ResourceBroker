﻿using ResourceBroker.Logic;
using ResourceBroker.Repositories;
using ResourceBroker.Enums;
using ResourceBroker.Utilities;

namespace ResourceBroker
{
    public partial class FormPackages : Form
    {
        private readonly PackageGwo _packageOptimizer;
        private readonly Automaton _automaton;
        private readonly IPackageRepository _package;
        private readonly IResourceRepository _resource;

        public FormPackages(PackageGwo packageOptimizer, Automaton automaton, IPackageRepository package, IResourceRepository resource)
        {
            InitializeComponent();

            _packageOptimizer = packageOptimizer;
            _automaton = automaton;
            _package = package;
            _resource = resource;
        }

        private async void FormPackages_Load(object sender, EventArgs e)
        {
            var imageList = new ImageList();
            imageList.ImageSize = new Size(256, 256);
            imageList.Images.Add(Image.FromFile("icons/PackageAutomaton.png"));
            imageList.Images.Add(Image.FromFile("icons/PackageGwo.png"));
            lsv_PackagesList.LargeImageList = imageList;

            await LoadPackages();
        }

        private async void btn_AddPackageGwo_Click(object sender, EventArgs e)
        {
            await CreatePackagesGwo();

            await Task.Delay(1000);

            await LoadPackages();
        }

        private async void btn_AddPackageAutomaton_Click(object sender, EventArgs e)
        {
            await CreatePackagesAutomaton();

            await Task.Delay(1000);

            await LoadPackages();
        }

        private async Task CreatePackagesGwo()
        {
            try
            {
                if (!await _resource.AnyAsync(r => !r.IsAllocated && r.PackageId == null))
                    return;

                var resources = await _resource.FindIncludeAsync(r => !r.IsAllocated && r.PackageId == null, x => x.Service);

                var packages = _packageOptimizer.CreatePackages(resources.ToList());
                foreach (var package in packages)
                {
                    if (package.Resources == null || !package.Resources.Any())
                        continue;

                    var packageResources = package.Resources;
                    package.Resources = null;

                    await Task.Delay(500);

                    _package.Add(package);
                    foreach (var resource in packageResources)
                    {
                        resource.Service = null;
                        resource.PackageId = package.Id;
                        resource.UpdatedAt = DateTime.Now;
                        _resource.Update(resource);
                    }

                    await Logger.Log($"Package created with |{package.QosScore}| QoS score and with |{package.Id}| id using Gray Wolf Optimization algorithm.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CreatePackagesAutomaton()
        {
            try
            {
                if (!await _resource.AnyAsync(r => !r.IsAllocated && r.PackageId == null))
                    return;

                var resources = await _resource.FindIncludeAsync(r => !r.IsAllocated && r.PackageId == null, x => x.Service);

                var createdPackages = _automaton.CreatePackages(resources.ToList());
                var package = createdPackages.OrderByDescending(x => x.QosScore).First();

                if (package.Resources == null || !package.Resources.Any())
                    return;

                var packageResources = package.Resources;
                package.Resources = null;

                await Task.Delay(500);

                _package.Add(package);
                foreach (var resource in packageResources)
                {
                    resource.Service = null;
                    resource.PackageId = package.Id;
                    resource.UpdatedAt = DateTime.Now;
                    _resource.Update(resource);
                }

                await Logger.Log($"Package created with |{package.QosScore}| QoS score and with |{package.Id}| id using Learning Automaton algorithm.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadPackages()
        {
            try
            {
                lsv_PackagesList.Items.Clear();

                var packages = await _package.GetAllPackages();
                foreach (var package in packages)
                {
                    var isCompliant = package.IsQosCompliant ? "Compliant" : "Not Compliant";
                    var totalCost = package.Resources?.Sum(r => r.Cost);
                    var description = $"{package.Description}\n\nQoS Score: {package.QosScore} ({ConvertToPercentage(package.QosScore)}%) | {isCompliant} | {Math.Round((double)totalCost!, 2)}$\n" +
                                      $"Creation Time: {package.TakenTimeForCreation}ms | Efficiency: {package.Efficiency} | Complexity: {package.Complexity}\n=========\n";
                    foreach (var resource in package.Resources.OrderBy(x => x.Type))
                    {
                        var resourceType = resource.Type switch
                        {
                            ResourceType.Cpu => "Cpu",
                            ResourceType.Gpu => "Gpu",
                            ResourceType.Ram => "Ram",
                            ResourceType.Ssd => "Ssd",
                            ResourceType.Hdd => "Hdd",
                            _ => "Unknown"
                        };

                        description += $"* {resource.Name} ({resource.Service!.Name}) ({resourceType}) | {resource.Capacity} | {resource.Cost}$\n";
                    }

                    lsv_PackagesList.Items.Add(new ListViewItem
                    {
                        Text = package.Title,
                        Name = description,
                        ImageIndex = package.Algorithm == PackageAlgorithmType.Gwo ? 1 : 0
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static int ConvertToPercentage(double number)
        {
            number = Math.Clamp(number, 1.0, 2.3);

            var percentage = (int)(((number - 1.0) / (2.3 - 1.0)) * 100);

            return Math.Max(percentage, 1);
        }

        private void lsv_PackagesList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selectedPackage = lsv_PackagesList.SelectedItems[0];

            MessageBox.Show(selectedPackage.Name, selectedPackage.Text, MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
