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

		public bool AddButtonClicked { get; set; }

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
					"Day",
					"Other Day",
					"Week",
					"Other Week",
				};
			}
		}

		public List<string> Durations
		{
			get
			{
				return new List<string>()
				{
					"1 Week",
					"2 weeks",
					"1 Month",
					"3 Months",
				};
			}
		}

		public ICommand AddButtonClick
		{
			get
			{
				return new MvxCommand(() => { AddGoal(); });
			}
		}

		public void AddGoal()
		{
			// Notifiy listeners that button was clicked
			RaisePropertyChanged(() => AddButtonClicked);
		}


	}
}
