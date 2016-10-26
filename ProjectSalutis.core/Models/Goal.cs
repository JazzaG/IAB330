using System;
namespace ProjectSalutis.core.Models
{
	public class Goal
	{
		public string GoalType { get; set; }
		public string Quantity { get; set; }
		public string Frequency { get; set; }
		public string Duration { get; set; }

		public int StepsCompleted { get; set; }
		public int TotalSteps { get; private set; }

		public Goal(string goalType, string quantity, string frequency, string duration)
		{
			this.GoalType = goalType;
			this.Quantity = quantity;
			this.Frequency = frequency;
			this.Duration = duration;

			this.StepsCompleted = 0;
			this.TotalSteps = CalculateTotalSteps();
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

		public void AddPercentage()
		{
			this.StepsCompleted += 1;
		}


	}
}
