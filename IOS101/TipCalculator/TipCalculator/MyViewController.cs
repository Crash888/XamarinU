using System;
using UIKit;
using CoreGraphics;

namespace TipCalculator
{
	public class MyViewController : UIViewController
	{
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			View.BackgroundColor = UIColor.Yellow;

			UITextField totalAmount = new UITextField(new CGRect(20, 28, View.Bounds.Width - 40, 35));

			//  Set some confirg on the text field
			totalAmount.KeyboardType = UIKeyboardType.DecimalPad;
			totalAmount.BorderStyle = UITextBorderStyle.RoundedRect;
			totalAmount.Placeholder = "Enter Total Amount";

			//  Can also set attributes within parentheses
			UIButton calcButton = new UIButton(UIButtonType.Custom)
			{
				Frame = new CGRect(20, 71, View.Bounds.Width - 40, 45),
				BackgroundColor = UIColor.FromRGB(0, 0.5f, 0),

			};

			calcButton.SetTitle("Calculate", UIControlState.Normal);

			UILabel resultLabel = new UILabel(new CGRect(0, 124, View.Bounds.Width, 40))
			{
				TextColor = UIColor.Blue,
				TextAlignment = UITextAlignment.Center,
				Font = UIFont.SystemFontOfSize(24),
				Text = "Tip is $0.00",
			};

			//  Add the views to the main view
			View.AddSubviews(totalAmount, calcButton, resultLabel);

			calcButton.TouchUpInside += (s, e) => {
				double value = 0;

				Double.TryParse(totalAmount.Text, out value);

				resultLabel.Text = string.Format("Tip is {0:C}", value * 0.2);

				totalAmount.ResignFirstResponder();

			};
		}
	}
}
