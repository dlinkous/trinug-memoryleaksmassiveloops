using System;
using System.Data.SqlClient;

namespace ConsoleApp
{
	internal class ItemRetriever
	{
		internal string RetrieveItemLargeMessage(int itemId)
		{
			SqlConnection con = null;
			try
			{
				con = new SqlConnection("Server=POSEIDON\\EXPRESS1;Database=MemoryLeaks;Trusted_Connection=true;Connection Timeout=5");
				con.Open();
				SqlCommand com = null;
				try
				{
					com = new SqlCommand("SELECT LargeMessage FROM dbo.Items WHERE ItemId = @ItemId", con);
					com.Parameters.AddWithValue("@ItemId", itemId);
					return (string)com.ExecuteScalar();
				}
				finally
				{
					com.Dispose();
				}
			}
			finally
			{
				con.Dispose();
			}
		}
	}
}
