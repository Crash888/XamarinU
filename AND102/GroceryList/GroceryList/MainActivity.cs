using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace GroceryList
{
	[Activity(Label = "Grocery List", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		public static List<Item> Items = new List<Item>();

		protected override void OnCreate(Bundle bundle)
		{
			Items.Add(new Item("Milk",     2));
			Items.Add(new Item("Crackers", 1));
			Items.Add(new Item("Apples",   5));

			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);

			FindViewById<Button>(Resource.Id.itemsButton  ).Click += OnItemsClick;
			FindViewById<Button>(Resource.Id.addItemButton).Click += OnAddItemClick;
			FindViewById<Button>(Resource.Id.aboutButton  ).Click += OnAboutClick;

			Console.WriteLine("I AM HERE #0000000-1");
			System.Diagnostics.Debug.WriteLine("I AM HERE #0000000-1 Diag");
			System.Diagnostics.Debug.WriteLine("I AM HERE #0000000-13423424234 Diag");

		}

		void OnItemsClick(object sender, EventArgs e)
		{
			//  Create an intent to open the ItemsActivity Activity
			var intent = new Intent(this, typeof(ItemsActivity));

			//  Start it up
			StartActivity(intent);

		}

		void OnAddItemClick(object sender, EventArgs e)
		{
			var intent = new Intent(this, typeof(AddItemActivity));

			//  Use StartActivityForResult when we expect data to be returned from the target
			StartActivityForResult(intent, 100);

		}

		void OnAboutClick(object sender, EventArgs e)
		{
			//  Starts an Activity without the need to create an Intent
			StartActivity(typeof(AboutActivity));

		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			// TODO
			System.Diagnostics.Debug.WriteLine("Target Activity Completed");

			//  Test the requestCode to ensure we know where the result is coming from
			//  Make sure the result is OK
			if (requestCode == 100 && resultCode == Result.Ok)
			{
				//  Get the data that was passed back to us
				string name = data.GetStringExtra("ItemName");
				int count = data.GetIntExtra("ItemCount", -1);

				//  Create a new Item for us
				Items.Add(new Item(name, count));

			}

		}
	}
}