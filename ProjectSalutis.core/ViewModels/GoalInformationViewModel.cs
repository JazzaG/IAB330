using System;
using MvvmCross.Core.ViewModels;
using ProjectSalutis.core.Interfaces;
using ProjectSalutis.core.Models;

namespace ProjectSalutis.core.ViewModels
{
	public class GoalInformationViewModel 
		: MvxViewModel
	{

		public Goal Goal { get; set; }

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

	}
}
