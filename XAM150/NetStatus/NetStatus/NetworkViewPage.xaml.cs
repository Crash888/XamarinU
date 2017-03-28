using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Xamarin.Forms;

using Xamarin.Forms;

namespace NetStatus
{
	public partial class NetworkViewPage : ContentPage
	{
		Label ConnectionDetails;

		public NetworkViewPage()
		{
			InitializeComponent();

			ConnectionDetails = new Label()
			{
				Text = "Connection Type",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
			};

			Content = ConnectionDetails;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			ConnectionDetails.Text = CrossConnectivity.Current.ConnectionTypes.First().ToString();

			if (CrossConnectivity.Current != null)
				CrossConnectivity.Current.ConnectivityChanged += UpdateNetworkInfo;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			if (CrossConnectivity.Current != null)
				CrossConnectivity.Current.ConnectivityChanged -= UpdateNetworkInfo;

		}
		private void UpdateNetworkInfo(object sender, ConnectivityChangedEventArgs e)
		{
			if (CrossConnectivity.Current != null && CrossConnectivity.Current.ConnectionTypes != null)
			{
				var connectionType = CrossConnectivity.Current.ConnectionTypes.FirstOrDefault();
				ConnectionDetails.Text = connectionType.ToString();
			}
		}
	}
}
