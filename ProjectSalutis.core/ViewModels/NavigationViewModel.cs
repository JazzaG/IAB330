using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace ProjectSalutis.core.ViewModels
{
    public class NavigationViewModel 
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
				return new MvxCommand(() => ShowViewModel<GoalViewModel>());
            }
        }

		public ICommand ContactCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<ContactListViewModel>());
			}
		}

    }
}
