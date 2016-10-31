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
		}
	}
}
