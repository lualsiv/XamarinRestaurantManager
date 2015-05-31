using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Tasky.Core.Models;

namespace TaskyAndroid.Adapters {
	/// <summary>
	/// Adapter that presents Tasks in a row-view
	/// </summary>
	public class OrderListAdapter : BaseAdapter<Order> {
		Activity context = null;
		IList<Order> orders = new List<Order>();
		
		public OrderListAdapter (Activity context, IList<Order> orders) : base ()
		{
			this.context = context;
			this.orders = orders;
		}
		
		public override Order this[int position]
		{
			get { return orders[position]; }
		}
		
		public override long GetItemId (int position)
		{
			return position;
		}
		
		public override int Count
		{
			get { return orders.Count; }
		}
		
		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			// Get our object for position
			var item = orders[position];			

			//Try to reuse convertView if it's not  null, otherwise inflate it from our item layout
			// gives us some performance gains by not always inflating a new view
			// will sound familiar to MonoTouch developers with UITableViewCell.DequeueReusableCell()
			var view = (convertView ?? 
					context.LayoutInflater.Inflate(
					Resource.Layout.TaskListItem, 
					parent, 
					false)) as LinearLayout;

			// Find references to each subview in the list item's view
			var txtName = view.FindViewById<TextView>(Resource.Id.NameText);
			var txtDescription = view.FindViewById<TextView>(Resource.Id.NotesText);

			//Assign item's values to the various subviews
			txtName.SetText (""+item.TableToServe, TextView.BufferType.Normal);
			txtDescription.SetText ("loolllzz", TextView.BufferType.Normal);

			//Finally return the view
			return view;
		}
	}
}