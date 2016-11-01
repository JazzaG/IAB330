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
    [Activity(
        Label = "Your Contact"
        , ParentActivity = typeof(ContactListView))]
    public class ContactInformationView : MvxActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ContactInformationView);

            // Show toast if contact deleted
            Button button = (Button)FindViewById<Button>(Resource.Id.contact_information_delete_btn);
            button.Click += delegate
            {
                Toast.MakeText(this, "Contact deleted", ToastLength.Short).Show();
            };
        }

        

    }
}