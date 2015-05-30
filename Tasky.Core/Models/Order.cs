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

		[SQLiteNetExtensions.Attributes.OneToMany(CascadeOperations = CascadeOperation.None)]
		public IList<Food> foods { get; set; }

		public double TotalCost{ get { return  foods.Sum(food=>food.price); } }

		public Order ()
		{
		}


	}
}

