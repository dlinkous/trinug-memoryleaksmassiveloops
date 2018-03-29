using System;
using System.Data.SqlClient;

namespace ConsoleApp
{
	internal class DatabaseUtility
	{
		internal void UseSqlCommand(Action<SqlCommand> act)
		{
			using (var con = new SqlConnection("Server=POSEIDON\\EXPRESS1;Database=MemoryLeaks;Trusted_Connection=true;Connection Timeout=5"))
			{
				con.Open();
				using (var com = new SqlCommand())
				{
					com.Connection = con;
					act(com);
				}
			}
		}
	}
}
