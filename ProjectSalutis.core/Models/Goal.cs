using System;
namespace ProjectSalutis.core.Models
{
	public class Goal
	{

		private int percentageCompleted;
		public int PercentageCompleted
		{
			get
			{
				return percentageCompleted;
			}

			set
			{
				percentageCompleted = value;
			}
		}

		private int quantity;
		public int Quantity
		{
			get
			{
				return quantity;
			}

			set
			{
				quantity = value;
			}
		}

		private GoalType goalType;
		public GoalType GoalType
		{
			get
			{
				return goalType;
			}

			set
			{
				goalType = value;
			}
		}

		private DateTime endDate;
		public DateTime EndDate
		{
			get
			{
				return endDate;
			}

			set
			{
				endDate = value;
			}
		}

		private int frequencyInSeconds;
		public int Frequency { get { return frequencyInSeconds; } }

		public Goal(GoalType goalType, int quantity, int frequency, DateTime endDate)
		{
			this.percentageCompleted = 0;
			this.quantity = quantity;
			this.goalType = goalType;
			this.frequencyInSeconds = frequency;
			this.endDate = endDate;
		}






	}
}
