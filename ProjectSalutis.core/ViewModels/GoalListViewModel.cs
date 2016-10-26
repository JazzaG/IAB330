using System.Collections.ObjectModel;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using ProjectSalutis.core.Interfaces;
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
			set { SetProperty(ref goals, value); }
		}

		private IProjectDatabase database;

		public GoalListViewModel(IProjectDatabase database)
		{
			this.database = database;
		}

		public void OnResume()
		{
			GetEntries();
		}

		public async void GetEntries()
		{
			var entries = await database.GetGoals();
			Goals.Clear();
			foreach (var entry in entries)
			{
				Goals.Add(entry);
			}
		}

	}
}
