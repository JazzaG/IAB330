using System;
using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

// Author: Shane Elford

namespace ProjectSalutis.droid.Views
{
	[Activity(Label = "Add New Contact")]
    class NewContactView : MvxActivity
    {

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.NewContactView);
		}

    }
}