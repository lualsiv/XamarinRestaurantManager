using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Tasky.Core.Models;
using Tasky.Core.DataAccess;
using TaskyAndroid;

namespace TaskyAndroid.Screens {
	/// <summary>
	/// View/edit a Task
	/// </summary>
	[Activity (Label = "TaskDetailsScreen")]			
	public class TaskDetailsScreen : Activity {
		Order order = new Order();
		Button cancelDeleteButton;
		EditText notesTextEdit;
		EditText nameTextEdit;
		Button saveButton;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			
			int taskID = Intent.GetIntExtra("TaskID", 0);
			if(taskID > 0) {
				order = OrderManager.GetOrder(taskID);
			}
			
			// set our layout to be the home screen
			SetContentView(Resource.Layout.TaskDetails);
			nameTextEdit = FindViewById<EditText>(Resource.Id.NameText);
			notesTextEdit = FindViewById<EditText>(Resource.Id.NotesText);
			saveButton = FindViewById<Button>(Resource.Id.SaveButton);
			
			// find all our controls
			cancelDeleteButton = FindViewById<Button>(Resource.Id.CancelDeleteButton);
			
			// set the cancel delete based on whether or not it's an existing task
			cancelDeleteButton.Text = (order.Id == 0 ? "Cancel" : "Delete");
			
			nameTextEdit.Text = order.TableToServe.ToString(); 
			notesTextEdit.Text = "LOLZZ";

			// button clicks 
			cancelDeleteButton.Click += (sender, e) => { CancelDelete(); };
			saveButton.Click += (sender, e) => { Save(); };
		}

		void Save()
		{
			order.TableToServe = int.Parse (nameTextEdit.Text);
			if (order.Id == 0) {
				OrderManager.SaveOrder (order);
			} else {
				OrderManager.UpdateOrder (order);
			}
			Finish();
		}
		
		void CancelDelete()
		{
			if (order.Id != 0) {
				OrderManager.DeleteOrder(order);
			}
			Finish();
		}
	}
}