using MvvmCross.Core.ViewModels;
using ProjectSalutis.core.Interfaces;
using ProjectSalutis.core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSalutis.core.ViewModels
{
    public class CompletedGoalsViewModel : MvxViewModel
    {

        private ObservableCollection<Goal> completedGoals = new ObservableCollection<Goal>();
        public ObservableCollection<Goal> CompletedGoals
        {
            get { return completedGoals; }
            set { SetProperty(ref completedGoals, value); }
        }

        private IProjectDatabase database;

        public CompletedGoalsViewModel(IProjectDatabase database)
        {
            this.database = database;
        }

        public void OnResume()
        {
            GetEntries();
        }

        public async void GetEntries()
        {
            var entries = await database.GetGoals();
            completedGoals.Clear();
            foreach (var entry in entries)
            {
                // Add if goal is completed
                if (entry.StepsCompleted >= entry.TotalSteps)
                {
                    completedGoals.Add(entry);
                }
            }
        }

    }
}
