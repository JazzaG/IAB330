// Author: Jared Gharib

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using Android.Widget;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using ProjectSalutis.core.ViewModels;

namespace ProjectSalutis.droid.Views
{
	[Activity(
		Label = "New Goal"
		, ParentActivity = typeof(GoalListView)
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
			// Build PendingIntent to take user to goal list screen
			// Thanks http://stackoverflow.com/a/18408355
			var requestToGoalListScreen = MvxViewModelRequest<GoalListViewModel>.GetDefaultRequest();
			var androidViewModelRequestTranslator = Mvx.Resolve<IMvxAndroidViewModelRequestTranslator>();
			var intent = androidViewModelRequestTranslator.GetIntentFor(requestToGoalListScreen);
			var pendingIntent = PendingIntent.GetActivity(this, 0, intent, 0);

			// Build the notification
			Notification.Builder builder = new Notification.Builder(this)
				.SetAutoCancel(true)
				.SetContentIntent(pendingIntent)
				.SetSmallIcon(Resource.Drawable.ic_notification)
				.SetContentTitle("Project Salutis")
				.SetContentText("You have goals to work towards!");

			// Show the notification
			NotificationManager manager = (NotificationManager)GetSystemService(Context.NotificationService);
			manager.Notify(1000, builder.Build());
		}

	}
}


