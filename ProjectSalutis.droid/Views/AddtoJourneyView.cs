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

            Spinner spinner = FindViewById<Spinner>(Resource.Id.journey_spinner);
            SeekBar seekbar = FindViewById<SeekBar>(Resource.Id.feeling_seekbar);
            Button add = FindViewById<Button>(Resource.Id.add_button);

            add.Click += delegate {

                string toast = string.Format("{0}/10 on {1} journey", seekbar.Progress, spinner.SelectedItem);
                Toast.MakeText(this, toast, ToastLength.Long).Show();
            };
        }
    }
}