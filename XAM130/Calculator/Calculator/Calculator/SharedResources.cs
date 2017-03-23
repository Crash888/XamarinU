using System;
using Xamarin.Forms;

namespace Calculator
{
	public static class SharedResources
	{
		public static Color OpButtonBkColor
		{
			get { return Color.FromRgb(0xff, 0xa5, 0); }
		}

		public static Color NumberButtonBkColor
		{
			get { return Color.White; }
		}

		public static Color ClearButtonBkColor
		{
			get { return Color.FromRgb(0x80, 0x80, 0x80); }
		}

	}
}
