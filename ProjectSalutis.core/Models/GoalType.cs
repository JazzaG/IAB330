using System;
using System.Collections.Generic;

namespace ProjectSalutis.core.Models
{
	public class GoalType
	{
		public static readonly GoalType RUN = new GoalType("Run", "kms");
		public static readonly GoalType JOG = new GoalType("Jog", "kms");
		public static readonly GoalType WALK = new GoalType("Walk", "kms");
		public static readonly GoalType BIKE = new GoalType("Bike", "kms");
		public static readonly GoalType DRINK_WATER = new GoalType("Drink Water", "glasses");
		public static readonly GoalType SWIM = new GoalType("Swim", "laps");
		public static readonly GoalType EXERCISE = new GoalType("Exercise", "hours");

		public static IEnumerable<GoalType> Values
		{
			get
			{
				yield return RUN;
				yield return JOG;
				yield return WALK;
				yield return BIKE;
				yield return DRINK_WATER;
				yield return SWIM;
				yield return EXERCISE;
			}
		}

		private string type;
		private string quantifier;

		GoalType(string type, string quantifier)
		{
			this.type = type;
			this.quantifier = quantifier;
		}

		public string Type { get { return type; } }
		public string Quantifier { get { return quantifier; } }
	}
}
