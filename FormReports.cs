using ResourceBroker.Enums;
using Microsoft.Extensions.DependencyInjection;
using ResourceBroker.Repositories;
using PlotType = ResourceBroker.Enums.PlotType;
using ResourceBroker.Models;

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

        private void ShowScatterChartForm(string title, string xAxisTitle, string yAxisTitle, List<KeyValuePair<double, double>> dataPoints)
        {
            using var scope = _serviceProvider.CreateScope();

            var chartForm = scope.ServiceProvider.GetRequiredService<FormChart>();
            chartForm.InitializeScatterChart(title, xAxisTitle, yAxisTitle, dataPoints);
        }

        private void ShowAaChartForm(string title, List<KeyValuePair<string, (double Accessibility, double Availability)>> dataPoints)
        {
            using var scope = _serviceProvider.CreateScope();

            var chartForm = scope.ServiceProvider.GetRequiredService<FormChart>();
            chartForm.InitializeAccessibilityAvailabilityChart(title, dataPoints);
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

        private async void btn_GwoTakenTimeVsQoS_Click(object sender, EventArgs e)
        {
            var packages = await _package.GetAllPackages();

            var dataPoints = packages
                .Where(p => p.Algorithm == PackageAlgorithmType.Gwo)
                .Select(p => new KeyValuePair<double, double>(p.QosScore, p.TakenTimeForCreation))
                .ToList();

            ShowScatterChartForm("GWO Execution Time vs. QoS Score", "QoS Score", "Execution Time (ms)", dataPoints);
        }

        private async void btn_GwoAccessibilityAvailability_Click(object sender, EventArgs e)
        {
            var packages = await _package.GetAllPackages();

            var dataPoints = packages
                .Where(p => p.Algorithm == PackageAlgorithmType.Gwo)
                .Select(p => new KeyValuePair<string, (double Accessibility, double Availability)>(
                    p.Title ?? "Unknown",
                    (
                        Accessibility: CalculateAccessibility(p),
                        Availability: CalculateAvailability(p)
                    )))
                .ToList();

            ShowAaChartForm("GWO Package Accessibility & Availability", dataPoints);
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

        private async void btn_AutomatonTakenTimeVsQoS_Click(object sender, EventArgs e)
        {
            var packages = await _package.GetAllPackages();

            var dataPoints = packages
                .Where(p => p.Algorithm == PackageAlgorithmType.Automaton)
                .Select(p => new KeyValuePair<double, double>(p.QosScore, p.TakenTimeForCreation))
                .ToList();

            ShowScatterChartForm("Automaton Execution Time vs. QoS Score", "QoS Score", "Execution Time (ms)", dataPoints);
        }

        private async void btn_AutomatonAccessibilityAvailability_Click(object sender, EventArgs e)
        {
            var packages = await _package.GetAllPackages();

            var dataPoints = packages
                .Where(p => p.Algorithm == PackageAlgorithmType.Automaton)
                .Select(p => new KeyValuePair<string, (double Accessibility, double Availability)>(
                    p.Title ?? "Unknown",
                    (
                        Accessibility: CalculateAccessibility(p),
                        Availability: CalculateAvailability(p)
                    )))
                .ToList();

            ShowAaChartForm("Automaton Package Accessibility & Availability", dataPoints);
        }

        #region Helpers
        public static double CalculateAccessibility(Package package)
        {
            if (package.Resources == null || !package.Resources.Any())
                return 0;

            var totalResources = package.Resources.Count;
            var accessibleResources = package.Resources.Count(r => !r.IsAllocated);

            // Calculate Accessibility: Proportion of unallocated resources
            var accessibility = (double)accessibleResources / totalResources;

            // Calculate Complexity: Diversity of resource types in the package
            var uniqueResourceTypes = package.Resources.Select(r => r.Type).Distinct().Count();
            var complexity = (double)uniqueResourceTypes / Enum.GetValues(typeof(ResourceType)).Length;

            // Calculate QoSScore: Weighted factors of capacity, cost, and response time
            const double capacityWeight = 0.4;
            const double costWeight = 0.3;
            const double responseTimeWeight = 0.3;

            var totalCapacity = package.Resources.Sum(r => r.Capacity);
            var totalCost = package.Resources.Sum(r => r.Cost);
            var totalResponseTime = package.Resources.Sum(r => r.ResponseTime);

            var normalizedCapacity = totalCapacity > 0
                ? package.Resources.Average(r => (double)r.Capacity / totalCapacity)
                : 0;

            var normalizedCost = totalCost > 0
                ? package.Resources.Average(r => 1 / (1 + r.Cost))
                : 0;

            var normalizedResponseTime = totalResponseTime > 0
                ? package.Resources.Average(r => 1 / (1 + r.ResponseTime))
                : 0;

            var qosScore = Math.Round(
                (capacityWeight * normalizedCapacity) +
                (costWeight * normalizedCost) +
                (responseTimeWeight * normalizedResponseTime), 2);

            // Combine metrics to compute an advanced accessibility score
            var combinedAccessibility = Math.Round(
                (0.5 * accessibility) +
                (0.3 * complexity) +
                (0.2 * qosScore), 2);

            return combinedAccessibility;
        }


        public static double CalculateAvailability(Package package)
        {
            if (package.Resources == null || !package.Resources.Any())
                return 0;

            // Normalize factors to make contributions meaningful
            const double capacityWeight = 0.4;
            const double costWeight = 0.3;
            const double responseTimeWeight = 0.3;

            var totalCapacity = package.Resources.Sum(r => r.Capacity);
            var totalCost = package.Resources.Sum(r => r.Cost);
            var totalResponseTime = package.Resources.Sum(r => r.ResponseTime);

            if (totalCapacity == 0 || totalCost == 0 || totalResponseTime == 0)
                return 0;

            var normalizedCapacity = package.Resources.Average(r => (double)r.Capacity / totalCapacity);
            var normalizedCost = package.Resources.Average(r => 1 / (1 + r.Cost)); // Lower cost is better
            var normalizedResponseTime = package.Resources.Average(r => 1 / (1 + r.ResponseTime)); // Lower time is better

            // Weighted sum of factors
            var availability = (capacityWeight * normalizedCapacity) +
                               (costWeight * normalizedCost) +
                               (responseTimeWeight * normalizedResponseTime);

            return Math.Round(availability, 2);
        }
        #endregion
    }
}
