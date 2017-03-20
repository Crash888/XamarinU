using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace TipCalculator
{
	[Activity(Label = "TipCalculator", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		//  Vars for the View elements
		//  Get the actual elements in OnCreate
		EditText inputBill;
		Button calculateButton;
		TextView outputTip;
		TextView outputTotal;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			//  Get the references for the fields
			inputBill = FindViewById<EditText>(Resource.Id.inputBill);
			calculateButton = FindViewById<Button>(Resource.Id.calculateButton);
			outputTip = FindViewById<TextView>(Resource.Id.outputTip);
			outputTotal = FindViewById<TextView>(Resource.Id.outputTotal);

			calculateButton.Click += OnCalculateClick;

		}

		void OnCalculateClick(object sender, EventArgs e)
		{
			//  Get the bill amount as a string
			string text = inputBill.Text;

			//  Convert the amount to a double
			var bill = double.Parse(text);

			//  Calculate the tip (15%)
			var tip = bill * 0.15;

			//  Calculate the bll total
			var total = bill + tip;

			outputTip.Text = tip.ToString();
			outputTotal.Text = total.ToString();

		}
	}
}

