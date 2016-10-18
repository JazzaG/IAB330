﻿// Author: Jared Gharib

using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using Android.Widget;
using MvvmCross.Droid.Views;

namespace ProjectSalutis.droid.Views
{
	[Activity(
		Label = "New Goal"
		, ScreenOrientation = ScreenOrientation.Portrait)]
	public class CreateGoalView : MvxActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.CreateGoalView);

			// Show a toast when the add button is clicked
			Button button = FindViewById<Button>(Resource.Id.goalAdd);
			button.Click += delegate {
				Log.Info("EventHandler", "Add button clicked");
				Toast.MakeText(this, "Add button clicked", ToastLength.Short).Show();
			};
		}

	}
}

