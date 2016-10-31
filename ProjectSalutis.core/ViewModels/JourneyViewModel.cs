using MvvmCross.Core.ViewModels;
using ProjectSalutis.core.Interfaces;
using System.Windows.Input;

namespace ProjectSalutis.core.ViewModels
{
    public class JourneyViewModel : MvxViewModel
    {
        private readonly IProjectDatabase projectDatabase;
        public ICommand AddJourneyCommand { get; private set; }
        public JourneyViewModel(IProjectDatabase projectDatabase)
        {
            this.projectDatabase = projectDatabase;
            AddJourneyCommand = new MvxCommand(() => ShowViewModel<AddtoJourneyViewModel>());
            List = new JourneyListViewModel(projectDatabase);
            Graph = new JourneyGraphViewModel(projectDatabase);
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
