using MvvmCross.Core.ViewModels;
using ProjectSalutis.core.Interfaces;
using System.Collections.Generic;
using System.Windows.Input;

namespace ProjectSalutis.core.ViewModels
{
    public class JourneyViewModel : MvxViewModel
    {
        private readonly IProjectDatabase projectDatabase;

        private List<string> filterOptions = new List<string> { "Show All", "Happiness", "Exercise", "Nutrition" };
        public List<string> FilterOptions
        {
            get
            {
                return filterOptions;
            }
        }

        private string filter;
        public string Filter
        {
            get
            {
                return filter;
            }
            set
            {
                SetProperty(ref filter, value);
                UpdateChildren();
            }
        }

        public ICommand AddJourneyCommand { get; private set; }
        public JourneyViewModel(IProjectDatabase projectDatabase)
        {
            this.projectDatabase = projectDatabase;
            AddJourneyCommand = new MvxCommand(() => ShowViewModel<AddtoJourneyViewModel>());
            List = new JourneyListViewModel(projectDatabase, this);
            Graph = new JourneyGraphViewModel(projectDatabase, this);
        }

        public void UpdateChildren()
        {
            Graph.UpdateEntries();
            List.UpdateEntries();
        }

        private JourneyListViewModel list;
        public JourneyListViewModel List
        {
            get { return list; }
            set { list = value; RaisePropertyChanged(() => List); }
        }

        private JourneyGraphViewModel graph;
        public JourneyGraphViewModel Graph
        {
            get { return graph; }
            set { graph = value; RaisePropertyChanged(() => Graph); }
        }
    }

    
}
