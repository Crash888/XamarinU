using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace People.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			string databasePath = FileAccessHelper.GetLocalFilePath("people.db3");

			LoadApplication(new App(databasePath));

			return base.FinishedLaunching(app, options);
		}
	}
}
