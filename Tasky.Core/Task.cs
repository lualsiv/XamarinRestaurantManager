using System;
using SQLite;

namespace Tasky.Core {
	/// <summary>
	/// Task business object
	/// </summary>
	public class Task {
		public Task ()
		{
		}

		[PrimaryKey, AutoIncrement]
        public int Id { get; set; }
		public string Name { get; set; }
		public string Notes { get; set; }
		public bool Done { get; set; }	// TODO: add this field to the user-interface
	}
}