using System;
using SQLite;
using Tasky.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Tasky.Core.DataAccess
{
	public static class OrderManager
	{
		static SQLiteConnection db;
		static OrderManager ()
		{
			// Create our connection
			string folder = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			db = new SQLiteConnection (System.IO.Path.Combine (folder, "notes.db"));
			db.CreateTable<Order>();
		}

		public static Order GetOrder(int id)
		{
			return db.Get<Order> (id);
		}

		public static IList<Order> GetOrders ()
		{

			var table = db.Table<Order> ();

			//Thank God for LINQ extensions
			return (from row in table
				select row).ToList<Order> ();

		}

		public static int SaveOrder (Order order)
		{
				return db.Insert (order);
		}

		public static int UpdateOrder(Order order){
			return db.Update (order);
		}


		public static int DeleteAllOrders(){
			return db.DeleteAll<Order>();
		}

		public static int DeleteOrder(Order order)
		{
			return db.Delete (order);
		}

	}
}

