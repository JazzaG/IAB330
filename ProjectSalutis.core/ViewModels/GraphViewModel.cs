using MvvmCross.Core.ViewModels;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using ProjectSalutis.core.Interfaces;
using ProjectSalutis.core.Models;
using System.Collections.ObjectModel;

namespace ProjectSalutis.core.ViewModels
{
    public class GraphViewModel : MvxViewModel
    {

        private ObservableCollection<JourneyEntry> entries = new ObservableCollection<JourneyEntry>();
        
        private readonly IProjectDatabase projectDatabase;

        public GraphViewModel(IProjectDatabase projectDatabase)
        {
            this.projectDatabase = projectDatabase;
            GetEntries();
        }

        public void OnResume()
        {
            GetEntries();
        }

        void GeneratePlotPoints()
        {
            
        }

        PlotModel plotModel;
        public PlotModel PlotModel
        {
            get { return plotModel; }
            set { SetProperty(ref plotModel, value); }
        }

        public async void GetEntries()
        {
            var mo = new PlotModel();
            var s1 = new LineSeries()
            {
                Background = OxyColors.White,
                Color = OxyColors.Blue,
                MarkerType = MarkerType.Circle,
                MarkerSize = 6,
                MarkerStroke = OxyColors.Blue,
                MarkerFill = OxyColors.SkyBlue,
                MarkerStrokeThickness = 1.5
            };
            mo.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, StringFormat = "dd MMM yy", AxislineColor = OxyColors.White, TextColor = OxyColors.White });
            mo.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = 0, Maximum = 10, AxislineColor = OxyColors.White, TextColor = OxyColors.White });

            var entries = await projectDatabase.GetJourneyEntries();
            foreach (var entry in entries)
            {
                s1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(entry.Timestamp), entry.Rating));
            }
            mo.Series.Add(s1);
            PlotModel = mo;
        }
    }
}
