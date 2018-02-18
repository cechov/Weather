namespace Weather
{
	public class Station {
		public Station(int number, string name, string department){
			Number = number;
			Name = name;
			Department = department;
		}
		public string Name { get; set; }
		public int Number { get; set; }
		public string Department { get; set; }
	}
}