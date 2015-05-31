using System;
using SQLite;

using SQLiteNetExtensions.Attributes;

namespace Tasky.Core.Models
{
	public class Food
	{

		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
		public double price { get; set;}

		public int OrderId { get; set; }

		public Food ()
		{
		}
	}
}

