namespace AutoRental.Models
{
	public class RentalViewModel
	{
		public List<Auto> Auto { get; set; }
		public List<Manufacturer> Manufacturer { get; set; }
		public List<Year> Year { get; set; }
		public List<ModelManufacturer> ModelManufacturer { get; set; }
	}
}
