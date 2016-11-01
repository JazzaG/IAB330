﻿using System;
using System.Collections.Generic;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using ProjectSalutis.core.Interfaces;
using ProjectSalutis.core.Models;

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
		public int Steps { get; set; }

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
					"2 Weeks",
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

		private IProjectDatabase database;

		public CreateGoalViewModel(IProjectDatabase database)
		{
			this.database = database;
		}

		public void AddGoal()
		{
			// If quantity is empty, set it to 1
			if (Quantity == "" || Quantity == null)
			{
				Quantity = "1";
			}

			// Create model
            Goal goal = CreateGoalInstance();

			// Store goal in database
			this.database.InsertGoal(goal);

			// Notifiy listeners that button was clicked
			RaisePropertyChanged(() => AddButtonClicked);

			// Navigation to goal list view
			ShowViewModel<GoalViewModel>();
		}

        private Goal CreateGoalInstance()
        {
            Goal goal = new Goal();
            goal.GoalType = GoalType;
            goal.Quantity = Quantity;
            goal.Frequency = Frequency;
            goal.Duration = Duration;

            goal.StepsCompleted = 0;
            goal.TotalSteps = CalculateTotalSteps();

            return goal;
        }

		private int CalculateTotalSteps()
		{
			// steps = (durationAsDays / freqAsDays) * numOfTimes
			int numOfTimes = Int32.Parse(Quantity);
			int frequencyAsDay = 0;
			int durationAsDay = 0;

			// Find frequency as days
			switch (Frequency)
			{
				case "Day":
					frequencyAsDay = 1;
					break;
				case "Other Day":
					frequencyAsDay = 2;
					break;
				case "Week":
					frequencyAsDay = 7;
					break;
				case "Other Week":
					frequencyAsDay = 14;
					break;
			}

			// Find duration as days
			switch (Duration)
			{
				case "1 Week":
					durationAsDay = 7;
					break;
				case "2 Weeks":
					durationAsDay = 14;
					break;
				case "1 Month":
					durationAsDay = 28;
					break;
				case "3 Months":
					durationAsDay = 84;
					break;
			}

			return durationAsDay / frequencyAsDay * numOfTimes;
		}


	}
}
