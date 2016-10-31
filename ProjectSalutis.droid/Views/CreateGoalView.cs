// Author: Jared Gharib

using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using Android.Widget;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using ProjectSalutis.core.ViewModels;

namespace ProjectSalutis.droid.Views
{
	[Activity(
		Label = "New Goal"
		, ScreenOrientation = ScreenOrientation.Portrait)]
	public class CreateGoalView : MvxActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.CreateGoalView);

			RegisterAddButtonClickListener();
			SetQuantityViewConstraints();
		}

		private void SetQuantityViewConstraints()
		{
			EditText text = (EditText)FindViewById<EditText>(Resource.Id.goalQuantity);
			text.Text = "1";

			// TODO: figure out a way to enforce a non-empty value
		}

		private void RegisterAddButtonClickListener()
		{
			var viewModel = (CreateGoalViewModel)this.ViewModel;
			new MvxPropertyChangedListener(viewModel).Listen<bool>(
				() => viewModel.AddButtonClicked,
				() =>
				{
					this.OnAddButtonClick();
				}
			);
		}

		private void OnAddButtonClick()
		{
			Toast.MakeText(this, "Add button clicked", ToastLength.Short).Show();
		}

	}
}


