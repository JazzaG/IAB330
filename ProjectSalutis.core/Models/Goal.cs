using System;
namespace ProjectSalutis.core.Models
{
	public class Goal
	{
		public int GoalId { get; set; }
		public string GoalType { get; set; }
		public string Quantity { get; set; }
		public string Frequency { get; set; }
		public string Duration { get; set; }

		public int StepsCompleted { get; set; }
		public int TotalSteps { get; set; }

		public string QuantityView
		{
			get
			{
				string view = Quantity + " time";
				if (Int32.Parse(Quantity) > 1)
				{
					view += "s";
				}

				view += " every " + Frequency;

				return view;
			}
		}

		public string DurationView
		{
			get
			{
				return "for " + Duration;
			}
		}

		public string PercentageView
		{
			get
			{
				int percentage = StepsCompleted / TotalSteps * 100;
				return percentage + "%";
			}
		}

		public Goal()
		{

		}

		public Goal(int id, string goalType, string quantity, string frequency, string duration, int totalSteps)
		{
			this.GoalId = id;
			this.GoalType = goalType;
			this.Quantity = quantity;
			this.Frequency = frequency;
			this.Duration = duration;
			this.TotalSteps = totalSteps;

			this.StepsCompleted = 0;
		}

		public void AddPercentage()
		{
			this.StepsCompleted += 1;
		}


	}
}
