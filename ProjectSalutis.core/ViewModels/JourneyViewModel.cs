using MvvmCross.Core.ViewModels;
using ProjectSalutis.core.Interfaces;
using ProjectSalutis.core.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProjectSalutis.core.ViewModels
{
    public class JourneyViewModel
        : MvxViewModel
    {
        private ObservableCollection<JourneyEntry> entries = new ObservableCollection<JourneyEntry>();

        public ObservableCollection<JourneyEntry> Entries
        {
            get { return entries; }
            set { SetProperty(ref entries, value); }
        }

        private readonly IProjectDatabase projectDatabase;

        public ICommand AddJourneyCommand { get; private set; }

        public JourneyViewModel(IProjectDatabase projectDatabase)
        {
            this.projectDatabase = projectDatabase;
            AddJourneyCommand = new MvxCommand(() => ShowViewModel<AddtoJourneyViewModel>());
        }

        public void OnResume()
        {
            GetEntries();
        }

        public async void GetEntries()
        {
            var entries = await projectDatabase.GetEntries();
            Entries.Clear();
            foreach (var entry in entries)
            {
                Entries.Add(entry);
            }
        }
    }
}
