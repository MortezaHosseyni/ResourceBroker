using OxyPlot.Series;
using OxyPlot;
using OxyPlot.WindowsForms;
using DataPoint = OxyPlot.DataPoint;
using OxyPlot.Axes;
using PlotType = ResourceBroker.Enums.PlotType;

namespace ResourceBroker
{
    public partial class FormChart : Form
    {
        private readonly PlotView _plotView;

        public FormChart()
        {
            InitializeComponent();

            _plotView = new PlotView
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(_plotView);
        }

        public void InitializeChart(string title, List<KeyValuePair<string, double>> dataPoints, PlotType plotType)
        {
            var plotModel = new PlotModel { Title = title };

            switch (plotType)
            {
                case PlotType.Bar:
                {
                    // Create BarSeries
                    var barSeries = new BarSeries
                    {
                        LabelPlacement = LabelPlacement.Inside,
                        LabelFormatString = "{0:.##}"
                    };

                    // Add data to BarSeries
                    foreach (var point in dataPoints)
                    {
                        barSeries.Items.Add(new BarItem { Value = point.Value, Color = point.Key.Contains("Automaton") ? OxyColors.Green : OxyColors.DarkGray });
                    }

                    plotModel.Series.Add(barSeries);

                    // Set up CategoryAxis for labels
                    plotModel.Axes.Add(new CategoryAxis
                    {
                        Position = AxisPosition.Left, // Bars should be vertical
                        Key = "CategoryAxis",
                        ItemsSource = dataPoints,
                        LabelField = "Key"
                    });

                    // Set up ValueAxis for numeric values
                    plotModel.Axes.Add(new LinearAxis
                    {
                        Position = AxisPosition.Bottom, // Horizontal values
                        MinimumPadding = 0.1,
                        MaximumPadding = 0.1,
                        AbsoluteMinimum = 0
                    });
                    break;
                }
                case PlotType.Line:
                {
                    // Create LineSeries
                    var lineSeries = new LineSeries { Title = "Line Data", Color = title.Contains("Automaton") ? OxyColors.Green : OxyColors.DarkGray };

                    foreach (var point in dataPoints)
                    {
                        lineSeries.Points.Add(new DataPoint(dataPoints.IndexOf(point), point.Value));
                    }

                    plotModel.Series.Add(lineSeries);

                    // Add axes
                    plotModel.Axes.Add(new CategoryAxis
                    {
                        Position = AxisPosition.Bottom,
                        ItemsSource = dataPoints,
                        LabelField = "Key"
                    });

                    plotModel.Axes.Add(new LinearAxis
                    {
                        Position = AxisPosition.Left,
                        MinimumPadding = 0.1,
                        MaximumPadding = 0.1
                    });
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(plotType), plotType, null);
            }

            // Assign PlotModel to PlotView
            _plotView.Model = plotModel;
        }

        public void InitializeScatterChart(string title, string xAxisTitle, string yAxisTitle, List<KeyValuePair<double, double>> dataPoints)
        {
            var plotModel = new PlotModel { Title = title };

            // Configure Axes
            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = xAxisTitle,
                MinimumPadding = 0.1,
                MaximumPadding = 0.1
            });

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = yAxisTitle,
                MinimumPadding = 0.1,
                MaximumPadding = 0.1
            });

            // Create Scatter Series
            var scatterSeries = new ScatterSeries
            {
                MarkerType = MarkerType.Diamond,
                MarkerSize = 5,
                MarkerFill = title.Contains("Automaton") ? OxyColors.Green : OxyColors.Black
            };

            foreach (var dataPoint in dataPoints)
            {
                scatterSeries.Points.Add(new ScatterPoint(dataPoint.Key, dataPoint.Value));
            }

            plotModel.Series.Add(scatterSeries);

            // Display in Form
            var plotView = new PlotView
            {
                Dock = DockStyle.Fill,
                Model = plotModel
            };

            var form = new Form
            {
                Text = title,
                Width = 800,
                Height = 600,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Maximized
            };
            form.Controls.Add(plotView);
            form.ShowDialog();
        }
    }
}
