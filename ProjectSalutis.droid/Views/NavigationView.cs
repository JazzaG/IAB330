using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Droid.Views;

namespace ProjectSalutis.droid.Views
{
    [Activity(Label = "Project Salutis",
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class NavigationView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.NavigationView);
        }
    }
}
