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
using ProjectSalutis.core.ViewModels;

namespace ProjectSalutis.droid.Views
{

    [Activity(
        Label = "Completed Goals"
        , ParentActivity = typeof(NavigationView))]
    public class CompletedGoalsView : MvxActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CompletedGoalsView);
        }
        
        protected override void OnResume()
        {
            base.OnResume();

            var viewModel = (CompletedGoalsViewModel)this.ViewModel;
            viewModel.OnResume();
        }


    }
}