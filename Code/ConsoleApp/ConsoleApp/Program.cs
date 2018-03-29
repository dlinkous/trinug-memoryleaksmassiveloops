using System;
using System.IO;
using System.Linq;

namespace ConsoleApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//RetrieveAnItem();
			//RetrieveTenItems();
			//RetrieveTwoThousandItems();
			//ClearLowIdItems();
			//ProcessDataFile();
			//ProcessDataFileAgain();
			//ReadAllFilesAtOnce();
			//ReadAllFilesIndividually();
			//FindCorrectMovie();
			//ProcessFirstMovie();
			//ProcessThreeMovies();
			//ProcessThreeMoviesTwice();
			//MaterializeAllMovies();
			//ReportAllProcessedMovieMetrics();
			//ReportFirstProcessedMovieMetric();
			//ReadOddItems();
			Console.ReadKey();
		}

		private static void RetrieveAnItem()
		{
			var retriever = new ItemRetriever();
			var largeMessage = retriever.RetrieveItemLargeMessage(1);
		}

		private static void RetrieveTenItems()
		{
			var retriever = new ItemRetriever();
			for (var i = 0; i < 10; i++)
			{
				var largeMessage = retriever.RetrieveItemLargeMessage(1);
			}
		}

		private static void RetrieveTwoThousandItems()
		{
			var retriever = new ItemRetriever();
			for (var i = 0; i < 2000; i++)
			{
				var largeMessage = retriever.RetrieveItemLargeMessage(1);
			}
		}

		private static void ClearLowIdItems()
		{
			var db = new DatabaseUtility();
			db.UseSqlCommand(com =>
			{
				com.CommandText = "UPDATE dbo.Items SET SmallMessage = '' WHERE ItemId < 3";
				com.ExecuteNonQuery();
			});
		}

		private static void ProcessDataFile()
		{
			var manager = new DataManager();
			var count = 0;
			do
			{
				count = manager.FindNextB();
				Console.WriteLine($"Data:{count}");
			} while (count > 0);
		}

		private static void ProcessDataFileAgain()
		{
			using (var manager = new DataManager2())
			{
				var count = 0;
				do
				{
					count = manager.FindNextB();
					Console.WriteLine($"Data:{count}");
				} while (count > 0);
			}
		}

		private static void ReadAllFilesAtOnce()
		{
			var reader = new FolderReader();
			foreach (var file in reader.ReadAllFiles())
			{
				Console.WriteLine(file.Length.ToString());
			}
		}

		private static void ReadAllFilesIndividually()
		{
			var reader = new FolderReader();
			foreach (var file in reader.ReadAllFilesIndividually())
			{
				Console.WriteLine(file.Length.ToString());
			}
		}

		private static void FindCorrectMovie()
		{
			var reader = new FolderReader();
			foreach (var movie in reader.ReadAllMovies())
			{
				if (movie.MovieNumber == 3)
				{
					// Process movie
					break;
				}
			}
		}

		private static void ProcessFirstMovie()
		{
			var reader = new FolderReader();
			var movie = reader.ReadAllMovies().First();
			// Process movie
		}

		private static void ProcessThreeMovies()
		{
			var reader = new FolderReader();
			foreach (var movie in reader.ReadThreeMovies())
			{
				// Process movie
			}
		}

		private static void ProcessThreeMoviesTwice()
		{
			var reader = new FolderReader();
			foreach (var movie in reader.ReadThreeMovies())
			{
				// Process movie
			}
			foreach (var movie in reader.ReadThreeMovies())
			{
				// Process movie
			}
		}

		private static void MaterializeAllMovies()
		{
			var reader = new FolderReader();
			var allMovies = reader.ReadAllMovies().ToList();
		}

		private static void ReportAllProcessedMovieMetrics()
		{
			var reader = new FolderReader();
			foreach (var processedMovie in reader.ReadAllProcessedMovies())
			{
				Console.WriteLine(processedMovie.Metric);
			}
		}

		private static void ReportFirstProcessedMovieMetric()
		{
			var reader = new FolderReader();
			var processedMovie = reader.ReadAllProcessedMovies().First();
			Console.WriteLine(processedMovie.Metric);
		}

		private static void ReadOddItems()
		{
			var retriever = new CompoundRetriever();
			foreach (var item in retriever.GetOddItems())
			{
				Console.WriteLine($"Item {item.ItemId} Message {item.LargeMessage.Trim()}");
			}
		}

		private static void StreamExample()
		{
			var memoryStream = new MemoryStream();
			memoryStream.Dispose();
		}
	}
}
