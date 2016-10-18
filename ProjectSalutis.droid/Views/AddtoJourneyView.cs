using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Views;
using System;

// Author: Samuel Dekker
// Will need to be switched across to work with MVVMX

namespace ProjectSalutis.droid.Views
{
    [Activity(Label = "Add to Journey")]
    public class AddtoJourneyView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.AddtoJourneyView);
        }
    }
}