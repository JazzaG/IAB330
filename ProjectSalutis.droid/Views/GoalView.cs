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
using Android.Content.PM;
using ProjectSalutis.core.ViewModels;

namespace ProjectSalutis.droid.Views
{
    [Activity(
        Label = "Goals",
        LaunchMode = LaunchMode.SingleTask,
        ScreenOrientation = ScreenOrientation.Portrait,
        ParentActivity = typeof(NavigationView))]
    public class GoalView : MvxTabActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.GoalView);

            GoalViewModel viewModel = (GoalViewModel)this.ViewModel;

            TabHost.TabSpec spec;
            Intent intent;

            // Create tab for active goals
            spec = TabHost.NewTabSpec("child1");
            spec.SetIndicator("Active");
            spec.SetContent(this.CreateIntentFor(viewModel.ListViewModel));
            TabHost.AddTab(spec);

            // Create tab for completed goals
            spec = TabHost.NewTabSpec("child2");
            spec.SetIndicator("Completed");
            spec.SetContent(this.CreateIntentFor(viewModel.CompletedViewModel));
            TabHost.AddTab(spec);
        }

    }
}