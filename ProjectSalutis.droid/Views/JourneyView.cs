using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using ProjectSalutis.core.ViewModels;

namespace ProjectSalutis.droid.Views
{
    [Activity(Label = "View for JourneyViewModel")]
    public class JourneyView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.JourneyView);
        }
        protected override void OnResume()
        {
            var vm = (JourneyViewModel)ViewModel;
            vm.OnResume();
            base.OnResume();
        }
    }
}