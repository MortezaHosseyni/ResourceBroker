using ResourceBroker.Enums;
using Microsoft.Extensions.DependencyInjection;
using ResourceBroker.Repositories;
using PlotType = ResourceBroker.Enums.PlotType;

namespace ResourceBroker
{
    public partial class FormReports : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IPackageRepository _package;

        public FormReports(IServiceProvider serviceProvider, IPackageRepository package)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _package = package;
        }

        private void ShowChartForm(string title, List<KeyValuePair<string, double>> dataPoints, PlotType chartType)
        {
            using var scope = _serviceProvider.CreateScope();

            var chartForm = scope.ServiceProvider.GetRequiredService<FormChart>();
            chartForm.InitializeChart(title, dataPoints, chartType);
            chartForm.ShowDialog();
        }

        private async void btn_Comparison_Click(object sender, EventArgs e)
        {
            var packages = await _package.GetAllPackages();

            var dataPoints = new List<KeyValuePair<string, double>>
            {
                new ("GWO", packages.Where(p => p.Algorithm == PackageAlgorithmType.Gwo).Average(p => p.Efficiency)),
                new ("Automaton", packages.Where(p => p.Algorithm == PackageAlgorithmType.Automaton).Average(p => p.Efficiency))
            };

            ShowChartForm("GWO vs Automaton Efficiency", dataPoints, PlotType.Bar);
        }

        private async void btn_GwoCurve_Click(object sender, EventArgs e)
        {
            var packages = await _package.GetAllPackages();

            var dataPoints = packages
                .Where(p => p.Algorithm == PackageAlgorithmType.Gwo)
                .OrderBy(p => p.TakenTimeForCreation)
                .Select((p, index) => new KeyValuePair<string, double>($"Iteration {index + 1}", p.Complexity))
                .ToList();

            ShowChartForm("GWO Convergence Curve", dataPoints, PlotType.Line);
        }

        private async void btn_GwoEfficiency_Click(object sender, EventArgs e)
        {
            var packages = await _package.GetAllPackages();

            var dataPoints = packages
                .Where(p => p.Algorithm == PackageAlgorithmType.Gwo)
                .Select(p => new KeyValuePair<string, double>(p.Title ?? "Unknown", p.Efficiency))
                .ToList();

            ShowChartForm("GWO Resource Utilization Efficiency", dataPoints, PlotType.Bar);
        }

        private async void btn_AutomatonCurve_Click(object sender, EventArgs e)
        {
            var packages = await _package.GetAllPackages();

            var dataPoints = packages
                .Where(p => p.Algorithm == PackageAlgorithmType.Automaton)
                .OrderBy(p => p.TakenTimeForCreation)
                .Select((p, index) => new KeyValuePair<string, double>($"Iteration {index + 1}", p.Complexity))
                .ToList();

            ShowChartForm("Automaton Convergence Curve", dataPoints, PlotType.Line);
        }

        private async void btn_AutomatonEfficiency_Click(object sender, EventArgs e)
        {
            var packages = await _package.GetAllPackages();

            var dataPoints = packages
                .Where(p => p.Algorithm == PackageAlgorithmType.Automaton)
                .Select(p => new KeyValuePair<string, double>(p.Title ?? "Unknown", p.Efficiency))
                .ToList();

            ShowChartForm("Automaton Resource Utilization Efficiency", dataPoints, PlotType.Bar);
        }
    }
}
