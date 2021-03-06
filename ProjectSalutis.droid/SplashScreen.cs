using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace ProjectSalutis.droid
{
    [Activity(
        Label = "ProjectSalutis.droid"
        , MainLauncher = true
        , Theme = "@style/Theme.Splash"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}
