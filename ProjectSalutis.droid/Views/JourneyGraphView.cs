using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Droid.Views;
using ProjectSalutis.core.ViewModels;

namespace ProjectSalutis.droid.Views
{
    [Activity(Label = "View for JourneyGraphViewModel",
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class JourneyGraphView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.JourneyGraphView);
        }

        protected override void OnResume()
        {
            var vm = (JourneyGraphViewModel)ViewModel;
            vm.OnResume();
            base.OnResume();
        }
    }
}