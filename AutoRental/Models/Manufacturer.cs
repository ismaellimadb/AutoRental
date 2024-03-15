using System.ComponentModel.DataAnnotations;

namespace AutoRental.Models
{
    public class Manufacturer
    {
        [Key] public int id_manufacturer { get; set; }
        public string name { get; set; }
        public string cnpj { get; set; }
        public int cep { get; set; }
    }
}
