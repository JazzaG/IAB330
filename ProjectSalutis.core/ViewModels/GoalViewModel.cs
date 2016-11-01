using MvvmCross.Core.ViewModels;
using ProjectSalutis.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectSalutis.core.ViewModels
{
    public class GoalViewModel : MvxViewModel
    {

        private IProjectDatabase database;

        public GoalListViewModel ListViewModel { get; private set; }

        public CompletedGoalsViewModel CompletedViewModel { get; private set; }

        public ICommand CreateGoalButtonClick
        {
            get
            {
                return new MvxCommand(() => OnCreateGoalClick());
            }
        }

        public GoalViewModel(IProjectDatabase database)
        {
            this.database = database;

            this.ListViewModel = new GoalListViewModel(database);
            this.CompletedViewModel = new CompletedGoalsViewModel(database);
        }

        public void OnCreateGoalClick()
        {
            ShowViewModel<CreateGoalViewModel>();
        }

    }
}
