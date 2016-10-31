using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using ProjectSalutis.core.ViewModels;

namespace ProjectSalutis.core.Models
{
	public class GoalListWrapper
	{
		private GoalListViewModel parent;

		public Goal Goal { get; set; }

		public GoalListWrapper(Goal goal, GoalListViewModel parent)
		{
			this.Goal = goal;
			this.parent = parent;
		}

		public ICommand ClickCommand
		{
			get
			{
				return new MvxCommand(() => this.parent.OnGoalClick(this.Goal));
			}
		}


	}
}
