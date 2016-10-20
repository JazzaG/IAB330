using System.Collections.Generic;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace ProjectSalutis.core.ViewModels
{
	public class CreateGoalViewModel
		: MvxViewModel
	{

		public string GoalType { get; set; }
		public string Quantity { get; set; }
		public string Frequency { get; set; }
		public string Duration { get; set; }

		public List<string> GoalTypes
		{
			get
			{
				return new List<string>() 
				{ 
					"Bike Ride",
					"Run / Walk / Jog",
					"Swim",
					"Pilates",
					"Yoga",
					"Exercise"
				};
			}
		}

		public ICommand AddButtonClick
		{
			get
			{
				return new MvxCommand(() => AddGoal());
			}
		}

		public void AddGoal()
		{

		}


	}
}
