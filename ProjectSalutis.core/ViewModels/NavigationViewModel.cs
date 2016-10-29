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

        public ICommand GraphCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<GraphViewModel>());
            }
        }

		public ICommand ContactCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<NewContactViewModel>());
			}
		}

		public ICommand GoalListCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<GoalListViewModel>());
			}
		}

    }
}
