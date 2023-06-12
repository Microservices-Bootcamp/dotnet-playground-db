using System.ComponentModel.DataAnnotations;

namespace SolidApi_HttpClient.Dtos
{
    public class Product
    {
        public string Name { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
    }

}