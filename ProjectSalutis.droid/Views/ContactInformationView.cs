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
using ProjectSalutis.core.Models;
using ProjectSalutis.core.ViewModels;

namespace ProjectSalutis.droid.Views
{
    [Activity(
        Label = "Your Contact"
        , ParentActivity = typeof(ContactListView))]
    public class ContactInformationView : MvxActivity
    {

        private Contact Contact { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ContactInformationView);

            // Store contact object
            ContactInformationViewModel viewModel = (ContactInformationViewModel)this.ViewModel;
            Contact = viewModel.Contact;

            // Show toast if contact deleted
            Button button = (Button)FindViewById<Button>(Resource.Id.contact_information_delete_btn);
            button.Click += delegate
            {
                Toast.MakeText(this, "Contact deleted", ToastLength.Short).Show();
            };

            // Register listeners on call buttons
            Button callPersonal = (Button)FindViewById<Button>(Resource.Id.contact_information_btn_call_personal);
            Button callOffice = (Button)FindViewById<Button>(Resource.Id.contact_information_btn_call_office);
            callPersonal.Click += (s, e) => OnCallPersonalClick();
            callOffice.Click += (s, e) => OnCallOfficeClick();
        }

        private void OnCallPersonalClick()
        {
            SendCallIntent(Contact.PersonalPhone);
        }

        private void OnCallOfficeClick()
        {
            SendCallIntent(Contact.OfficePhone);
        }

        private void SendCallIntent(string number)
        {
            Intent intent;

            // If there is a number, call it. If not open dialer
            if (number != null && !number.Equals(""))
            {
                Android.Net.Uri uri = Android.Net.Uri.Parse(String.Format("tel:{0}", number));
                intent = new Intent(Intent.ActionCall, uri);
            } else
            {
                intent = new Intent(Intent.ActionDial);
            }

            StartActivity(intent);
        }
        

    }
}