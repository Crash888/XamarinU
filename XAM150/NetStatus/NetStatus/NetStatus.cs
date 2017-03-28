using System;

using Xamarin.Forms;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;

namespace NetStatus
{
	public class App : Application
	{
		public App()
		{
			MainPage = CrossConnectivity.Current.IsConnected ? (Page)new NetworkViewPage() : new NoNetworkPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
			base.OnStart();
			CrossConnectivity.Current.ConnectivityChanged += HandleConnectivityChanged;

		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		void HandleConnectivityChanged(object sender, ConnectivityChangedEventArgs e) 
		{
			Type currentPage = this.MainPage.GetType();

			if (e.IsConnected && currentPage != typeof(NetworkViewPage))
				this.MainPage = new NetworkViewPage();
			else if (!e.IsConnected && currentPage != typeof(NoNetworkPage))
				this.MainPage = new NoNetworkPage();
		}
	}
}
