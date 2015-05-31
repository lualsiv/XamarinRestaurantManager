using System;
using SQLite;
using Tasky.Core.Models;
using SQLiteNetExtensions.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Tasky.Core.DataAccess
{
	public static class FoodManager
	{
		static SQLiteConnection db;
		static FoodManager ()
		{
			// Create our connection
			string folder = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			db = new SQLiteConnection (System.IO.Path.Combine (folder, "notes.db"));
			db.CreateTable<Food>();
		}

		public static Food GetFood(int id)
		{
			return db.Get<Food> (id);
		}

		public static IList<Food> GetFoods ()
		{

			var table = db.Table<Food> ();

			//Thank God for LINQ extensions
			return (from row in table
				select row).ToList<Food> ();

		}

		public static int SaveFood (Food food)
		{
			return db.Insert (food);
		}

		public static int UpdateFood(Food food){
			return db.Update(food);
		}

		public static int DeleteFood(Food food)
		{
			return db.Delete (food);
		}


	}
}

