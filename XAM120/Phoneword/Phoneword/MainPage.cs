using System;
using Xamarin.Forms;
using Core;

namespace Phoneword
{
	public class MainPage : ContentPage
	{
		//  Used to handle device specific values.
		double spacing = Device.OnPlatform<double>(
			40,  // iOS
			20,  // Android
			20  //  Windows Phone
		);

		Entry phoneNumberEntry;
		Button translateButton;
		Button callButton;

		string translatedNumber;

		public MainPage()
		{

			//  View padding
			this.Padding = new Thickness(20, spacing, 20, 20);

			var layout = new StackLayout();

			layout.VerticalOptions = LayoutOptions.FillAndExpand;
			layout.HorizontalOptions = LayoutOptions.FillAndExpand;

			//  Spacing between children
			layout.Spacing = 15;

			var phoneWordLabel = new Label { Text = "Enter a Phoneword:" };
			phoneNumberEntry =  new Entry { Text = "1-855-XAMARIN" };

			translateButton = new Button { Text = "Translate" };
			translateButton.Clicked += OnTranslate;

			callButton = new Button { Text = "Call", IsEnabled = false };
			callButton.Clicked += OnCall;

			layout.Children.Add(phoneWordLabel);
			layout.Children.Add(phoneNumberEntry);
			layout.Children.Add(translateButton);
			layout.Children.Add(callButton);

			this.Content = layout;

			/*
			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.Center,
				Children = {
						new Label {
							HorizontalTextAlignment = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
					}
				}
			};
			*/
		}

		void OnTranslate(object sender, EventArgs args)
		{
			string phoneNumber = phoneNumberEntry.Text;

			translatedNumber = PhonewordTranslator.ToNumber(phoneNumber);

			if (!string.IsNullOrEmpty(translatedNumber))
			{
				callButton.Text = "Call " + translatedNumber;
				callButton.IsEnabled = true;
			}
			else
			{
				callButton.Text = "Call";
				callButton.IsEnabled = false;
			}
		}

		async void OnCall(object sender, EventArgs args)
		{
			if (await this.DisplayAlert("Dial a Number", "Would you like to call " + translatedNumber + "?", "Yes", "No"))
			{
				//  User answered Yes to dialing
				var dialer = DependencyService.Get<IDialer>();

				if (dialer != null)
				{
					await dialer.DialAsync(translatedNumber);
				}
			}
		}
	}
}
