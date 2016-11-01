using System.Collections.ObjectModel;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using ProjectSalutis.core.Models;

namespace ProjectSalutis.core.ViewModels
{
	public class GoalListViewModel
		: MvxViewModel
	{

		private ObservableCollection<Goal> goals = new ObservableCollection<Goal>();
		public ObservableCollection<Goal> Goals 
		{
			get { return goals; }
		}

		//public ICommand GoalClickCommand
		//{
		//	get
		//	{
		//		//return new MvxCommand(() => );
		//	}
		//}

	}
}
