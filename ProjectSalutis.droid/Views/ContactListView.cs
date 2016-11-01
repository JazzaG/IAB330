
using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Droid.Views;
using ProjectSalutis.core.ViewModels;

namespace ProjectSalutis.droid.Views
{
    [Activity(
        Label = "Contacts"
        , ParentActivity = typeof(NavigationView)
        , LaunchMode = LaunchMode.SingleTask)]
    public class ContactListView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ContactListView);
        }

        protected override void OnResume()
        {
            base.OnResume();

            var viewModel = (ContactListViewModel)this.ViewModel;
            viewModel.OnResume();
        }

    }
}