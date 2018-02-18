using Android.Widget;
using Android.App;
using System.Collections.Generic;

namespace Weather
{

	public class CountyAdapter : BaseAdapter<Department>
	{
		private Activity activity;
		private IList<Department> counties;

		public CountyAdapter(Activity activity, IEnumerable<Department> counties)
		{
			this.activity = activity;
			this.counties = new List<Department> (counties);
		}

        public override long GetItemId(int position)
        {
            return counties[position].Id;
        }

        public override int Count
		{
			get {
				return counties.Count;
			}
		}

		public override Department this [int index]
		{
			get {
				return counties[index];
			}
		}


		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			var department = this[position];
			var imageResourceId = GetImage (department.Name);
			var name = department.Name;
			if (imageResourceId == -1) {
				name += " - " + department.Name;
			}
			var view = activity.LayoutInflater.Inflate (Android.Resource.Layout.ActivityListItem, null);

			view.FindViewById<TextView> (Android.Resource.Id.Text1)
				.Text = name;

			view.FindViewById<ImageView> (Android.Resource.Id.Icon)
				.SetImageResource (imageResourceId);

			return view;
		}

		int GetImage (string department)
		{
			switch (department) {
			case "HEDMARK":
				return Resource.Drawable.Hedmark;
			case "AKERSHUS":
				return Resource.Drawable.Akershus;
			case "BUSKERUD":
				return Resource.Drawable.Buskerud;
			case "ØSTFOLD":
				return Resource.Drawable.Oestfold;
			case "SØR-TRØNDELAG":
				return Resource.Drawable.Soer_Troendelag;
			case "NORD-TRØNDELAG":
				return Resource.Drawable.Nord_Troendelag;
			case "OPPLAND":
				return Resource.Drawable.Oppland;
			case "OSLO":
				return Resource.Drawable.Oslo;
			case "VESTFOLD":
				return Resource.Drawable.Vestfold;
			case "HORDALAND":
				return Resource.Drawable.Hordaland;
			case "TELEMARK":
				return Resource.Drawable.Telemark;
			case "AUST-AGDER":
				return Resource.Drawable.Aust_Agder;
			case "VEST-AGDER":
				return Resource.Drawable.Vest_Agder;
			case "ROGALAND":
				return Resource.Drawable.Rogaland;
			case "SOGN OG FJORDANE":
				return Resource.Drawable.Sogn_og_Fjordane;
			case "MØRE OG ROMSDAL":
				return Resource.Drawable.Moere_og_Romsdal;
			case "NORDLAND":
				return Resource.Drawable.Nordland;
			case "TROMS":
				return Resource.Drawable.Troms;
			case "FINNMARK":
				return Resource.Drawable.Finnmark;
			default:
				return 0;
			}
		}
	}
}

