using System;
using SQLite;
using System.Linq;
using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;

namespace Tasky.Core.Models
{
	public class Order
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public int TableToServe { get; set; }

		public Order ()
		{
		}


	}
}

