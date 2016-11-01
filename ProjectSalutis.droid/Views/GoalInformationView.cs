using System;
using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using ProjectSalutis.core.ViewModels;

namespace ProjectSalutis.droid.Views
{
	[Activity(Label = "Your Goal"
	          , ParentActivity = typeof(GoalListView))]
	public class GoalInformationView : MvxActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.GoalInformationView);

			// Show toast if goal deleted
			var viewModel = (GoalInformationViewModel)this.ViewModel;
			new MvxPropertyChangedListener(viewModel).Listen<int>(
				() => viewModel.GoalDeleted,
				() =>
				{
					Toast.MakeText(this, "Goal deleted", ToastLength.Short).Show();
				}
			);

			// Show dialog to create new journey entry if goal is completed
			new MvxPropertyChangedListener(viewModel).Listen<bool>(
				() => viewModel.GoalCompleted,
				() =>
				{
					this.HandleCompletedGoal(viewModel);
				}
			);
		}

		private void HandleCompletedGoal(GoalInformationViewModel viewModel)
		{
			// Show a dialog to take the user to AddToJourneyView
			AlertDialog.Builder builder = new AlertDialog.Builder(this);
			builder
				.SetTitle("Congratulations!")
				.SetMessage("Well done on completing a goal. Would you like to add a journey entry?")
                .SetCancelable(false)
				.SetNegativeButton("Not now", (sender, e) =>
				{
                    viewModel.GoToGoalListScreen();
				})
				.SetPositiveButton("Sure", (sender, e) =>
				{
					viewModel.GoToAddJourneyEntry();
				});

			Dialog dialog = builder.Create();
			dialog.Show();
		}
	}
}
