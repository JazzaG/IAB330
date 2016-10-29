using MvvmCross.Core.ViewModels;
using ProjectSalutis.core.Interfaces;
using ProjectSalutis.core.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProjectSalutis.core.ViewModels
{
    public class JourneyViewModel : MvxViewModel
    {
        private ObservableCollection<JourneyEntry> entries = new ObservableCollection<JourneyEntry>();

        public ObservableCollection<JourneyEntry> Entries
        {
            get { return entries; }
            set { SetProperty(ref entries, value); }
        }

        private readonly IProjectDatabase projectDatabase;

        public ICommand AddJourneyCommand { get; private set; }
        public ICommand ChangeViewCommand { get; private set; }

        public JourneyViewModel(IProjectDatabase projectDatabase)
        {
            this.projectDatabase = projectDatabase;
            AddJourneyCommand = new MvxCommand(() => ShowViewModel<AddtoJourneyViewModel>());
            ChangeViewCommand = new MvxCommand(() => ChangeView());
        }

        private void ChangeView()
        {
            Close(this);
            ShowViewModel<GraphViewModel>();
        }

        public void OnResume()
        {
            UpdateEntries();
        }

        public async void UpdateEntries()
        {
            var entries = await projectDatabase.GetJourneyEntries();
            Entries.Clear();
            foreach (var entry in entries)
            {
                Entries.Add(entry);
            }
        }
    }
}
