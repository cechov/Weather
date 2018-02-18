namespace Weather
{
	public class Elements{
		public const string MinimumTemperature = "213";
		public const string MaximumTemperature = "215";

		public static string GetString(params string[] elements){
			return string.Join(",", elements);
		}
	}
}