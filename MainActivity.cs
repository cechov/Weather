using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Weather
{
	[Activity (Label = "Main", MainLauncher = true)]			
	public class MainActivity : Activity
	{
		private int selectedStationNumber;
		private string selectedStationName;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.MainLayout);

            var selectedStationLabel = FindViewById<TextView>(Resource.Id.selectedStationLabel);
            selectedStationName = Intent.GetStringExtra("STATION_NAME") ?? "Data not available";
            selectedStationLabel.Text = selectedStationName;
            selectedStationNumber = Intent.GetIntExtra("STATION_NUMBER", -1);

            Button selectStation = FindViewById<Button> (Resource.Id.selectStation);
			selectStation.Click += delegate {
                StartActivity(new Intent(this, typeof(SelectCountyActivity)));
				StartActivityForResult(new Intent(this, typeof(SelectCountyActivity)), 0);
			};
			Button lastWeek = FindViewById<Button> (Resource.Id.lastWeek);
			lastWeek.Click += delegate {
				var intent = new Intent(this, typeof(LastWeek));
				intent.PutExtra("STATION_NUMBER", selectedStationNumber);
				StartActivity(intent);
			};
		}

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			if (resultCode == Result.Ok) {
                var selectedStationLabel = FindViewById<TextView> (Resource.Id.selectedStationLabel);
				selectedStationName = data.GetStringExtra("STATION_NAME");
				selectedStationLabel.Text = selectedStationName;
				selectedStationNumber = data.GetIntExtra ("STATION_NUMBER", -1);
			}
		}

		protected override void OnSaveInstanceState (Bundle outState)
		{
			outState.PutString ("STATION_NAME", selectedStationName);
			outState.PutInt ("STATION_NUMBER", selectedStationNumber);

			base.OnSaveInstanceState (outState);
		}

		protected override void OnRestoreInstanceState (Bundle savedInstanceState)
		{
			var selectedStationLabel = FindViewById<TextView> (Resource.Id.selectedStationLabel);
			selectedStationName = savedInstanceState.GetString("STATION_NAME");
			selectedStationLabel.Text = selectedStationName;
			selectedStationNumber = savedInstanceState.GetInt ("STATION_NUMBER", -1);

			base.OnRestoreInstanceState (savedInstanceState);
		}
	}
}

