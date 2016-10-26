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

		public List<string> Frequencies
		{
			get
			{
				return new List<string>()
				{
					"Every Day",
					"Every Other Day",
					"Every Week",
					"Every Other Week",
				};
			}
		}

		public List<string> Durations
		{
			get
			{
				return new List<string>()
				{
					"For a Week",
					"For two weeks",
					"For a month",
					"For three months",
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
