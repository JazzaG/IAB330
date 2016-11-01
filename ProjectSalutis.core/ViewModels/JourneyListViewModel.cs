using MvvmCross.Core.ViewModels;
using ProjectSalutis.core.Interfaces;
using ProjectSalutis.core.Models;
using System.Collections.ObjectModel;

namespace ProjectSalutis.core.ViewModels
{
    public class JourneyListViewModel
    : MvxViewModel
    {
        private ObservableCollection<JourneyEntry> entries = new ObservableCollection<JourneyEntry>();

        public ObservableCollection<JourneyEntry> Entries
        {
            get { return entries; }
            set { SetProperty(ref entries, value); }
        }

        private readonly IProjectDatabase projectDatabase;
        
        public JourneyListViewModel(IProjectDatabase projectDatabase)
        {
            this.projectDatabase = projectDatabase;
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
