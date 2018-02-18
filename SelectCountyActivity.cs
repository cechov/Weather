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
	[Activity (Label = "Select county", Icon = "@drawable/icon")]
	public class SelectCountyActivity : ListActivity
	{
		private CountyAdapter adapter;
        private int selectedStationNumber;
        private string selectedStationName;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.SelectStationLayout);

		}

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {
                selectedStationName = data.GetStringExtra("STATION_NAME");
                selectedStationNumber = data.GetIntExtra("STATION_NUMBER", -1);
                var intent = new Intent(this, typeof(MainActivity));
                intent.PutExtra("STATION_NAME", selectedStationName);
                intent.PutExtra("STATION_NUMBER", selectedStationNumber);
                SetResult(Result.Ok, intent);
                Finish();
                StartActivity(intent);
            }
        }

        protected override void OnStart ()
		{
			base.OnStart ();

			ThreadPool.QueueUserWorkItem (o => LoadStations());
		}

		private void LoadStations()
		{
			var service = new FakeMetDataService ();
			var result = service.getCountyTypes ("", "");
			var stations = result.Select (c => new Department (c.countyID, c.countyName));

			RunOnUiThread (() => LoadStationsComplete (stations));
		}

		private void LoadStationsComplete(IEnumerable<Department> stations)
		{
			this.adapter = new CountyAdapter(this, stations);
			this.ListAdapter = this.adapter;
			FindViewById<RelativeLayout> (Resource.Id.loadingPanel).Visibility = ViewStates.Gone;
		}

		protected override void OnListItemClick (ListView l, View v, int position, long id)
		{
            var county = adapter[position];
            var intent = new Intent (this, typeof(SelectStationActivity));
            intent.PutExtra("COUNTY_NAME", county.Name);
            StartActivityForResult(intent, 0);
		}

		private void ShowToast(string text){
			var toast = Toast.MakeText (this, text, ToastLength.Short);
			toast.Show ();
		}
	}
}


