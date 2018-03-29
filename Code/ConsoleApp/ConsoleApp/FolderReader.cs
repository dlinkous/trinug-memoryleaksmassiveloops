using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp
{
	internal class FolderReader
	{
		internal List<byte[]> ReadAllFiles()
		{
			var list = new List<byte[]>();
			for (var i = 0; i < 50; i++)
			{
				list.Add(File.ReadAllBytes("./SpaceX_Falcon_Heavy_launch.mp4"));
			}
			return list;
		}

		internal IEnumerable<byte[]> ReadAllFilesIndividually()
		{
			for (var i = 0; i < 50; i++)
			{
				yield return File.ReadAllBytes("./SpaceX_Falcon_Heavy_launch.mp4");
			}
		}

		internal IEnumerable<Movie> ReadAllMovies()
		{
			for (var i = 0; i < 50; i++)
			{
				yield return new Movie() { MovieNumber = i + 1, MovieData = File.ReadAllBytes("./SpaceX_Falcon_Heavy_launch.mp4") };
			}
		}

		internal IEnumerable<Movie> ReadThreeMovies()
		{
			for (var i = 0; i < 3; i++)
			{
				Console.WriteLine($"Reading a movie!");
				yield return new Movie() { MovieNumber = i + 1, MovieData = File.ReadAllBytes("./SpaceX_Falcon_Heavy_launch.mp4") };
			}
		}

		internal IEnumerable<ProcessedMovie> ReadAllProcessedMovies()
		{
			var random = new Random();
			foreach (var movie in ReadAllMovies())
			{
				yield return new ProcessedMovie() { OriginalMovie = movie, Metric = random.Next() };
			}
		}
	}
}
