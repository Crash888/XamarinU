using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace GroceryList
{
	[Activity(Label = "About")]			
	public class AboutActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.About);

			FindViewById<Button>(Resource.Id.learnMoreButton).Click += OnLearnMoreClick;
		}

		void OnLearnMoreClick(object sender, EventArgs e)
		{
			//  Going to opena  web browser.
			//  Make a new Intent and set the Action
			var intent = new Intent();
			intent.SetAction(Intent.ActionView);

			//  Now set the Data of the Intent
			intent.SetData(Android.Net.Uri.Parse("http://www.xamarin.com"));

			//  With the above data set, Android knows to launch a browser
			StartActivity(intent);

		}
	}
}