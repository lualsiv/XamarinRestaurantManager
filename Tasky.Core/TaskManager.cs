using System;
using System.Collections.Generic;
using SQLite;

namespace Tasky.Core {
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

			//I am baffled by the fact that there is no built-in
			//functionality for such a simple task.
			var taskQuery = (from task in table
			                 select task);

			var result = new List<Task> ();
			foreach (var task in taskQuery){
				result.Add (task);
			}
		
			return result;
		}
		
		public static int SaveTask (Task item)
		{
				return db.Insert (item);
		}
		
		public static int DeleteTask(int id)
		{
			return db.Delete (id);
		}
	}
}