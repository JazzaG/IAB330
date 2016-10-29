
using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using ProjectSalutis.core.ViewModels;

namespace ProjectSalutis.droid.Views
{
    [Activity(Label = "View for GraphViewModel")]
    public class GraphView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.GraphView);
        }
        protected override void OnResume()
        {
            var vm = (GraphViewModel)ViewModel;
            vm.OnResume();
            base.OnResume();
        }
    }
}