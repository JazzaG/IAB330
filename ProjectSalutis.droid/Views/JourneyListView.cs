using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Views;
using ProjectSalutis.core.ViewModels;

namespace ProjectSalutis.droid.Views
{
    [Activity(Label = "View for JourneyListViewModel")]
    public class JourneyListView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.JourneyListView);
        }

        protected override void OnResume()
        {
            var vm = (JourneyListViewModel)ViewModel;
            vm.OnResume();
            base.OnResume();
        }
    }
}