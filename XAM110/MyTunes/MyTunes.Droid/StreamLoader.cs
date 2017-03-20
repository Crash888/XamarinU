using System;
using System.IO;
using Android.Content;

namespace MyTunes
{
	public class StreamLoader : IStreamLoader
	{
		public StreamLoader()
		{
		}

		private readonly Context context;

		public StreamLoader(Context context)
		{
			this.context = context;
		}

		public Stream GetStreamForFilename(string filename)
		{
			return context.Assets.Open(filename);
		}
	}
}
