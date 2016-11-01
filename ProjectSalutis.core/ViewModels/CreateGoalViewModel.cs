using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace ProjectSalutis.core.ViewModels
{
	public class CreateGoalViewModel
		: MvxViewModel
	{

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
