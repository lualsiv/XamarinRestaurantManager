using System;
using System.Collections.Generic;
using SQLite;
using System.Linq;
using Tasky.Core.Models;

namespace Tasky.Core.DataAccess {
	/// <summary>
	/// Manager classes are an abstraction on the data access layers
	/// </summary>
	public static class TaskManager {

		//Yuck static...but I am lazy so...
		static SQLiteConnection db;
		static TaskManager ()
		{
			// Create our connection
			string folder = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			db = new SQLiteConnection (System.IO.Path.Combine (folder, "notes.db"));
			db.CreateTable<Task>();
		}
		
		public static Task GetTask(int id)
		{
			return db.Get<Task> (id);
		}
		
		public static IList<Task> GetTasks ()
		{
			
			var table = db.Table<Task> ();

			//Thank God for LINQ extensions
			return (from task in table
			        select task).ToList<Task> ();
		
		}
		
		public static int SaveTask (Task item)
		{
				return db.Insert (item);
		}
		
		public static int DeleteTask(Task item)
		{
			return db.Delete (item);
		}
	}
}