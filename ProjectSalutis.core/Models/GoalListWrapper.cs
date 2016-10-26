using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using ProjectSalutis.core.ViewModels;

namespace ProjectSalutis.core.Models
{
	public class GoalListWrapper
	{
		private Goal goal;
		private GoalListViewModel parent;

		public GoalListWrapper(Goal goal, GoalListViewModel parent)
		{
			this.goal = goal;
			this.parent = parent;
		}

		public string PercentageView
		{
			get
			{
				return goal.PercentageView;
			}
		}

		public string GoalType
		{
			get
			{
				return goal.GoalType;
			}
		}

		public string QuantityView
		{
			get
			{
				return goal.QuantityView;
			}
		}

		public string DurationView
		{
			get
			{
				return goal.DurationView;
			}
		}

		public ICommand ClickCommand
		{
			get
			{
				return new MvxCommand(() => this.parent.OnGoalClick(this.goal));
			}
		}


	}
}
