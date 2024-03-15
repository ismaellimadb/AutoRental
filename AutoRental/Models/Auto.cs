using System.ComponentModel.DataAnnotations;

namespace AutoRental.Models
{
	public class Auto
	{
		[Key] public int id_auto { get; set; }
		public string plate { get; set; }
		public int id_manufacturer { get; set; }
		public string model { get; set; }
		public DateTime year { get; set; }
	}
}
