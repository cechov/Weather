
using System;

using Android.App;
using Android.Content;
using Android.OS;

namespace Weather
{
	[Activity (Label = "LastWeek")]			
	public class LastWeek : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			var selectedStation = Intent.GetIntExtra ("station.number", -1).ToString();
			var timeseriesType = TimeSeriesType.DailyValues;
			var elements = Elements.GetString (
				Elements.MinimumTemperature,
				Elements.MaximumTemperature);

			var service = new FakeMetDataService ();
			var from = DateTime.Today.AddDays(-7).ToString ("yyyy-MM-dd");

			var metData = service.getMetData (timeseriesType, "", from, "", selectedStation, elements, "", "", "");
		}

		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult (requestCode, resultCode, data);
		}
	}
}

