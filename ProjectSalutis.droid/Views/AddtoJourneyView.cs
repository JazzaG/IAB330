using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Views;
using System;

namespace ProjectSalutis.droid.Views
{
    [Activity(Label = "Add to Journey",
        ParentActivity = typeof(JourneyView),
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class AddtoJourneyView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.AddtoJourneyView);
        }
    }
}