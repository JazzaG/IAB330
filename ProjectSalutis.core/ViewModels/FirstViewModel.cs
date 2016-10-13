using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace ProjectSalutis.core.ViewModels
{
    public class FirstViewModel 
        : MvxViewModel
    {

		public ICommand JourneyCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<JourneyViewModel>());
			}
		}

		public ICommand GoalCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<CreateGoalViewModel>());
			}
		}

		public ICommand ContactCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<NewContactViewModel>());
			}
		}

    }
}
