using SQLite.Net.Attributes;
using System;
namespace ProjectSalutis.core.Models
{
	public class Goal
	{
        [PrimaryKey, AutoIncrement]
		public int GoalId { get; set; }
		public string GoalType { get; set; }
		public string Quantity { get; set; }
		public string Frequency { get; set; }
		public string Duration { get; set; }

		public int StepsCompleted { get; set; }
		public int TotalSteps { get; set; }

        [Ignore]
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

        [Ignore]
        public string DurationView
		{
			get
			{
				return "for " + Duration;
			}
		}

        [Ignore]
        public string PercentageView
		{
			get
			{
				double percentage = (double) StepsCompleted / TotalSteps * 100;

				string val = percentage + "";
				if (val.Contains("."))
				{
					val = val.Split('.')[0];
				}

				return val + "%";
			}
		}

		public Goal()
		{

		}

		public void AddPercentage()
		{
			if (StepsCompleted < TotalSteps)
			{
				this.StepsCompleted += 1;
			}
		}


	}
}
