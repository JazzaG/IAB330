using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using ProjectSalutis.core.Interfaces;
using ProjectSalutis.core.Models;

namespace ProjectSalutis.core.ViewModels
{
	public class GoalListViewModel
		: MvxViewModel
	{

		private ObservableCollection<GoalListWrapper> goals = new ObservableCollection<GoalListWrapper>();
		public ObservableCollection<GoalListWrapper> Goals 
		{
			get { return goals; }
			set { SetProperty(ref goals, value); }
		}

		private IProjectDatabase database;

		public GoalListViewModel(IProjectDatabase database)
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
			Goals.Clear();
			foreach (var entry in entries)
			{
                // Add if goal is not completed
                if (entry.StepsCompleted < entry.TotalSteps)
                {
                    Goals.Add(new GoalListWrapper(entry, this));
                }
			}
		}

		public void OnGoalClick(Goal goal)
		{
			var parameters = new Dictionary<string, string>
			{
				{ "goal-id", goal.GoalId + "" }
			};

			ShowViewModel<GoalInformationViewModel>(parameters);
		}

	}
}
