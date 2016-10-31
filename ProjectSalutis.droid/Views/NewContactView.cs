using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;

namespace ProjectSalutis.droid.Views
{
	[Activity(Label = "Add New Contact"
	          , ParentActivity = typeof(NavigationView))]
    class NewContactView : MvxActivity
    {

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.NewContactView);
		}

    }
}