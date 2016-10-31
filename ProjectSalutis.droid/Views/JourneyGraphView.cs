using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using ProjectSalutis.core.ViewModels;

namespace ProjectSalutis.droid.Views
{
    [Activity(Label = "View for JourneyGraphViewModel")]
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