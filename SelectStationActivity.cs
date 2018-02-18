using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Weather.eklima.met.no;
using System.Linq;
using System.Threading;

namespace Weather
{
	[Activity (Label = "Select station", Icon = "@drawable/icon")]
	public class SelectStationActivity : ListActivity
	{
        private string selectedCountyName;
        private StationAdapter adapter;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.SelectStationLayout);

            selectedCountyName = Intent.GetStringExtra("COUNTY_NAME") ?? "Data not available";
        }

        protected override void OnStart ()
		{
			base.OnStart ();

			ThreadPool.QueueUserWorkItem (o => LoadStations(selectedCountyName));
		}

		private void LoadStations(string dep)
		{
			var service = new FakeMetDataService ();
			var result = service.getStationsProperties ("", "");
            var list = from item in result where item.department == dep select new { item.stnr, item.name, item.department }; 
            var stations = list.Select (s => new Station (s.stnr, s.name, s.department));

            RunOnUiThread(() => LoadStationsComplete(stations));
		}

		private void LoadStationsComplete(IEnumerable<Station> stations)
		{
			this.adapter = new StationAdapter(this, stations);
			this.ListAdapter = this.adapter;
			FindViewById<RelativeLayout> (Resource.Id.loadingPanel).Visibility = ViewStates.Gone;
		}

		protected override void OnListItemClick (ListView l, View v, int position, long id)
		{
			var station = adapter[position];
			var intent = new Intent (this, typeof(SelectCountyActivity));
			intent.PutExtra ("STATION_NAME", station.Name);
			intent.PutExtra ("STATION_NUMBER", station.Number);
            SetResult (Result.Ok, intent);

            Finish ();
		}

		private void ShowToast(string text){
			var toast = Toast.MakeText (this, text, ToastLength.Short);
			toast.Show ();
		}
	}
}


