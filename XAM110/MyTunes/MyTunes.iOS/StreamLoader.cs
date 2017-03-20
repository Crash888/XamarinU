using System;
using System.IO;

namespace MyTunes
{
	public class StreamLoader : IStreamLoader
	{
		public StreamLoader()
		{
		}

		public Stream GetStreamForFilename(string filename)
		{
			return File.OpenRead(filename);
		}

 	}
}
