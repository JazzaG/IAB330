using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Views;
using ProjectSalutis.core.ViewModels;

namespace ProjectSalutis.droid.Views
{
    [Activity(Label = "Journey",
        ParentActivity = typeof(NavigationView),
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class JourneyView : MvxTabActivity
    {
        protected JourneyViewModel JourneyViewModel
        {
            get { return base.ViewModel as JourneyViewModel; }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.JourneyView);


            TabHost.TabSpec spec;
            Intent intent;

            spec = TabHost.NewTabSpec("child1");
            spec.SetIndicator("Graph");
            spec.SetContent(this.CreateIntentFor(JourneyViewModel.Graph));
            TabHost.AddTab(spec);

            spec = TabHost.NewTabSpec("child2");
            spec.SetIndicator("List");
            spec.SetContent(this.CreateIntentFor(JourneyViewModel.List));
            TabHost.AddTab(spec);
        }
    }
}