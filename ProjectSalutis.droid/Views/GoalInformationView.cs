using System;
using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace ProjectSalutis.droid.Views
{
	[Activity(Label = "Your Goal")]
	public class GoalInformationView : MvxActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.GoalInformationView);
		}
	}
}
