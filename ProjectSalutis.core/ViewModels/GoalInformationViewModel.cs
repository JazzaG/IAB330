using System;
using MvvmCross.Core.ViewModels;
using ProjectSalutis.core.Interfaces;
using ProjectSalutis.core.Models;

namespace ProjectSalutis.core.ViewModels
{
	public class GoalInformationViewModel 
		: MvxViewModel
	{

		private Goal Goal { get; set; }

		private IProjectDatabase database;

		public GoalInformationViewModel(IProjectDatabase database)
		{
			this.database = database;
		}

		public void Init()
		{

		}

	}
}
