using System;

namespace ConsoleApp
{
	internal class Customer
	{
		internal int Id { get; set; }
		internal string Name { get; set; }
		internal int Logins { get; private set; }

		internal void IncrementLogins() => Logins++;
	}
}
