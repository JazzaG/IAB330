// Author: Jared Gharib

using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Droid.Views;
using ProjectSalutis.core.ViewModels;

namespace ProjectSalutis.droid.Views
{
	[Activity(
		Label = "Goals"
		, ParentActivity = typeof(NavigationView)
        , LaunchMode = LaunchMode.SingleTask
		, ScreenOrientation = ScreenOrientation.Portrait)]
	public class GoalListView : MvxActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.GoalListView);
		}

		protected override void OnResume()
		{
			base.OnResume();

			var viewModel = (GoalListViewModel)this.ViewModel;
			viewModel.OnResume();
		}

	}
}


