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
		Label = "Goals"
		, ScreenOrientation = ScreenOrientation.Portrait)]
	public class GoalListView : MvxActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.GoalListView);
		}

	}
}

