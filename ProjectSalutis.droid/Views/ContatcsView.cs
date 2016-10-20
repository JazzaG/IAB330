using System;
using Android.Content.PM;
using Android.App;
using Android.OS;
using Android.Util;
using Android.Widget;
using MvvmCross.Droid.Views;

// Author: Shane Elford

namespace ProjectSalutis.droid.Views
{
    [Activity(
        Label = "Contacts"
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class ContatcsView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Contacts);
        }
    }
}