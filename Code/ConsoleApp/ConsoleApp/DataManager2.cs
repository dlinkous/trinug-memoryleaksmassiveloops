using System;
using System.IO;

namespace ConsoleApp
{
	internal sealed class DataManager2 : IDisposable
	{
		private readonly StreamReader reader = new StreamReader("./DataFile.txt");

		public void Dispose() => reader.Dispose();

		internal int FindNextB()
		{
			var count = 0;
			var charactersRead = 0;
			do
			{
				var buffer = new char[1];
				charactersRead = reader.Read(buffer, 0, 1);
				if (charactersRead > 0)
				{
					switch (buffer[0])
					{
						case 'A':
							count++;
							break;
						case 'B':
							return count;
						default:
							throw new InvalidOperationException();
					}
				}
			} while (charactersRead > 0);
			return 0;
		}
	}
}
