using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace GroceryList
{
	[Activity(Label = "Add Item")]			
	public class AddItemActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.AddItem);

			FindViewById<Button>(Resource.Id.saveButton  ).Click += OnSaveClick;
			FindViewById<Button>(Resource.Id.cancelButton).Click += OnCancelClick;
		}

		void OnSaveClick(object sender, EventArgs e)
		{
			string name = FindViewById<EditText>(Resource.Id.nameInput).Text;
			int count = int.Parse(FindViewById<EditText>(Resource.Id.countInput).Text);

			// Prepare to send back the entered data to the previous Activity
			var intent = new Intent();
			intent.PutExtra("ItemName", name);
			intent.PutExtra("ItemCount", count);

			//  Load the data we want to return
			//  Note:  This does not end the current Activity
			SetResult(Result.Ok, intent);

			//  Now we are finishing the Activity
			Finish();

		}

		void OnCancelClick(object sender, EventArgs e)
		{
			base.Finish();
		}
	}
}