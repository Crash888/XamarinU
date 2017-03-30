using System;

namespace People.iOS
{
	public class FileAccessHelper
	{
		public FileAccessHelper()
		{
		}

		public static string GetLocalFilePath(string filename)
		{
			//  Personal Directory Path
			string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

			//  Cannot access the Library directly.  So, from Personal folder back up one directory
			//  and then move into the Library directory
			string libPath = System.IO.Path.Combine(dirPath, "..", "Library");

			//  Create Library if it does not exist
			if (!System.IO.Directory.Exists(libPath))
			{
				System.IO.Directory.CreateDirectory(libPath);
			}

			return System.IO.Path.Combine(libPath, filename);
		}
	}
}
