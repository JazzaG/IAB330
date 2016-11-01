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
            PlotModel = new PlotModel();
            PlotModel.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, StringFormat = "dd MMM yy", AxislineColor = OxyColors.White, TextColor = OxyColors.White });
            PlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = -0.5, Maximum = 10.5, AxislineColor = OxyColors.White, TextColor = OxyColors.White, IsZoomEnabled = false, IsPanEnabled = false });
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
                Color = OxyColors.Red,
                MarkerType = MarkerType.Circle,
                MarkerSize = 6,
                MarkerStroke = OxyColors.DarkRed,
                MarkerFill = OxyColors.PaleVioletRed,
                MarkerStrokeThickness = 1.5
            };
            var s2 = new LineSeries()
            {
                Color = OxyColors.Blue,
                MarkerType = MarkerType.Circle,
                MarkerSize = 6,
                MarkerStroke = OxyColors.DarkBlue,
                MarkerFill = OxyColors.LightBlue,
                MarkerStrokeThickness = 1.5
            };
            var s3 = new LineSeries()
            {
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
