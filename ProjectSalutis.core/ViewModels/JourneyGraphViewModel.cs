using MvvmCross.Core.ViewModels;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using ProjectSalutis.core.Interfaces;

namespace ProjectSalutis.core.ViewModels
{
    public class JourneyGraphViewModel : MvxViewModel
    {
        private PlotModel plotModel;
        public PlotModel PlotModel
        {
            get { return plotModel; }
            set { SetProperty(ref plotModel, value); }
        }

        private readonly IProjectDatabase projectDatabase;

        public JourneyGraphViewModel(IProjectDatabase projectDatabase)
        {
            this.projectDatabase = projectDatabase;
            PlotModel = new PlotModel() { LegendBackground = OxyColor.FromAColor(200, OxyColors.White), LegendBorder = OxyColors.Black };
            PlotModel.PlotAreaBorderColor = OxyColors.Transparent;
            PlotModel.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, StringFormat = "dd MMM yy" });
            PlotModel.Axes.Add(new LinearAxis { AxislineStyle = LineStyle.None, Position = AxisPosition.Left, IsAxisVisible = false, Minimum = -0.5, Maximum = 4.5, MajorStep = 1, MinorStep = 1,  IsZoomEnabled = false, IsPanEnabled = false });
        }

        public void OnResume()
        {
            UpdateEntries();
        }

        public async void UpdateEntries()
        {
            PlotModel.Series.Clear();

            var s1 = new LineSeries()
            {
                Title = "Happiness",
                Color = OxyColors.Red,
                MarkerType = MarkerType.Circle,
                MarkerSize = 6,
                MarkerStroke = OxyColors.DarkRed,
                MarkerFill = OxyColors.IndianRed,
                MarkerStrokeThickness = 1.5
            };
            var s2 = new LineSeries()
            {
                Title = "Exercise",
                Color = OxyColors.Blue,
                MarkerType = MarkerType.Circle,
                MarkerSize = 6,
                MarkerStroke = OxyColors.DarkBlue,
                MarkerFill = OxyColors.LightBlue,
                MarkerStrokeThickness = 1.5
            };
            var s3 = new LineSeries()
            {
                Title = "Nutrition",
                Color = OxyColors.Green,
                MarkerType = MarkerType.Circle,
                MarkerSize = 6,
                MarkerStroke = OxyColors.DarkGreen,
                MarkerFill = OxyColors.LightGreen,
                MarkerStrokeThickness = 1.5
            };

            var entries = await projectDatabase.GetJourneyEntries();
            foreach (var entry in entries)
            {
                if (entry.Category == "Happiness") {
                    s1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(entry.Timestamp), entry.Rating));
                }
                else if (entry.Category == "Exercise")
                {
                    s2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(entry.Timestamp), entry.Rating));
                }
                else if (entry.Category == "Nutrition")
                {
                    s3.Points.Add(new DataPoint(DateTimeAxis.ToDouble(entry.Timestamp), entry.Rating));
                }
            }

            PlotModel.InvalidatePlot(true);

            PlotModel.Series.Add(s1);
            PlotModel.Series.Add(s2);
            PlotModel.Series.Add(s3);
        }
    }
}
