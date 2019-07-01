using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TweetAssignment
{
	public static class FileReadWorker
	{
		public static string[] ReadFile(string filepath)
		{

			List<string> lines = new List<string>();
			try
			{
				using (var streamReader = new StreamReader(filepath))
				{
					string line;

					while ((line = streamReader.ReadLine()) != null)
					{
						lines.Add(line);
					}
				}
			}
			catch(FileNotFoundException ex)
			{
				Console.WriteLine("Please make sure the file you are trying to read is in the project folder:{0}", ex);
			}

			return lines.ToArray();
		}
	}
}
