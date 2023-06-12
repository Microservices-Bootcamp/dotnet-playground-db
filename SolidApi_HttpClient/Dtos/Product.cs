using System.ComponentModel.DataAnnotations;

namespace Products.Controllers.Dtos
{
    public class Product
    {
        public string Name { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
    }

}