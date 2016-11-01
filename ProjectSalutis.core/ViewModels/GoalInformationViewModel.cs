using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using ProjectSalutis.core.Interfaces;
using ProjectSalutis.core.Models;

namespace ProjectSalutis.core.ViewModels
{
	public class GoalInformationViewModel
		: MvxViewModel
	{

		public Goal Goal { get; set; }

		public ICommand AddPercentageClickCommand
		{
			get
			{
				return new MvxCommand(() => OnAddPercentageClick());
			}
		}

		public ICommand DeleteGoalClickCommand
		{
			get
			{
				return new MvxCommand(() => OnDeleteClick());
			}
		}

		public bool GoalCompleted { get; set; }

		private IProjectDatabase database;

		public GoalInformationViewModel(IProjectDatabase database)
		{
			this.database = database;
		}

		protected override void InitFromBundle(IMvxBundle bundle)
		{
			int goalId = Int32.Parse(bundle.Data["goal-id"]);
			LoadGoal(goalId);
		}

		private async void LoadGoal(int goalId)
		{
			var goals = await database.GetGoals();
			foreach (var goal in goals)
			{
				if (goal.GoalId == goalId)
				{
					Goal = goal;
				}
			}
		}

		private void OnAddPercentageClick()
		{
			Goal.AddPercentage();
			database.UpdateGoal(Goal);

			RaisePropertyChanged(() => Goal);

			// Notify view if goal is completed
			if (Goal.StepsCompleted >= Goal.TotalSteps)
			{
				RaisePropertyChanged(() => GoalCompleted);
			}
		}

		public int GoalDeleted { get; set; }

		private void OnDeleteClick()
		{
			database.DeleteGoal(Goal);
			RaisePropertyChanged(() => GoalDeleted);
			ShowViewModel<GoalViewModel>();
		}

		public void GoToAddJourneyEntry()
		{
			ShowViewModel<AddtoJourneyViewModel>();
		}

        public void GoToGoalScreen()
        {
            ShowViewModel<GoalViewModel>();
        }

	}
}
