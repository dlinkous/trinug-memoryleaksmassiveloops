using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleApp
{
	internal class CompoundRetriever
	{
		internal IEnumerable<Item> GetOddItems()
		{
			using (var con = new SqlConnection("Server=POSEIDON\\EXPRESS1;Database=MemoryLeaks;Trusted_Connection=true;Connection Timeout=5"))
			{
				con.Open();
				using (var com = new SqlCommand("SELECT ItemId, SmallMessage, LargeMessage FROM dbo.Items WHERE ItemId % 2 = 1", con))
				{
					using (var rdr = com.ExecuteReader())
					{
						while (rdr.Read())
						{
							yield return new Item()
							{
								ItemId = rdr.GetInt32(0),
								SmallMessage = rdr.GetString(1),
								LargeMessage = rdr.GetString(2)
							};
						}
					}
				}
			}
		}
	}
}
