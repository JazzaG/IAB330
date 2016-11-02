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
        private JourneyViewModel parent;

        public JourneyGraphViewModel(IProjectDatabase projectDatabase, JourneyViewModel parent)
        {
            this.projectDatabase = projectDatabase;
            this.parent = parent;
            PlotModel = new PlotModel()
            {
                //LegendBackground = OxyColor.FromAColor(200, OxyColors.White),
                //LegendBorder = OxyColors.Black,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendPosition = LegendPosition.TopCenter,
                LegendPlacement = LegendPlacement.Outside
            };
            PlotModel.PlotAreaBorderColor = OxyColors.Transparent;
            PlotModel.Axes.Add(new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                StringFormat = "dd MMM yy"
            });
            PlotModel.Axes.Add(new LinearAxis
            {
                AxislineStyle = LineStyle.None,
                Position = AxisPosition.Left,
                IsAxisVisible = false,
                Minimum = -0.5,
                Maximum = 4.5,
                MajorStep = 1,
                MinorStep = 1,
                IsZoomEnabled = false,
                IsPanEnabled = false });
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
                Color = OxyColor.FromRgb(241, 100, 119),
                MarkerType = MarkerType.Circle,
                MarkerSize = 6,
                MarkerStroke = OxyColor.FromRgb(241, 100, 119),
                MarkerFill = OxyColor.FromRgb(241, 100, 119),
                MarkerStrokeThickness = 1.5,
                Smooth = true
            };
            var s2 = new LineSeries()
            {
                Title = "Exercise",
                Color = OxyColor.FromRgb(247, 150, 34),
                MarkerType = MarkerType.Circle,
                MarkerSize = 6,
                MarkerStroke = OxyColor.FromRgb(247, 150, 34),
                MarkerFill = OxyColor.FromRgb(247, 150, 34),
                MarkerStrokeThickness = 1.5,
                Smooth = true
            };
            var s3 = new LineSeries()
            {
                Title = "Nutrition",
                Color = OxyColor.FromRgb(0, 35, 93),
                MarkerType = MarkerType.Circle,
                MarkerSize = 6,
                MarkerStroke = OxyColor.FromRgb(0, 35, 93),
                MarkerFill = OxyColor.FromRgb(0, 35, 93),
                MarkerStrokeThickness = 1.5,
                Smooth = true
            };

            var entries = await projectDatabase.GetJourneyEntries();
            foreach (var entry in entries)
            {
                if (entry.Category == "Happiness" && (parent.Filter == "Happiness" || parent.Filter == "Show All")) {
                    s1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(entry.Timestamp), entry.Rating));
                }
                else if (entry.Category == "Exercise" && (parent.Filter == "Exercise" || parent.Filter == "Show All"))
                {
                    s2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(entry.Timestamp), entry.Rating));
                }
                else if (entry.Category == "Nutrition" && (parent.Filter == "Nutrition" || parent.Filter == "Show All"))
                {
                    s3.Points.Add(new DataPoint(DateTimeAxis.ToDouble(entry.Timestamp), entry.Rating));
                }
            }

            PlotModel.InvalidatePlot(true);

            if (parent.Filter == "Happiness" || parent.Filter == "Show All")
            {
                PlotModel.Series.Add(s1);
            }
            if (parent.Filter == "Exercise" || parent.Filter == "Show All")
            {
                PlotModel.Series.Add(s2);
            }
            if (parent.Filter == "Nutrition" || parent.Filter == "Show All")
            {
                PlotModel.Series.Add(s3);
            }
        }
    }
}
