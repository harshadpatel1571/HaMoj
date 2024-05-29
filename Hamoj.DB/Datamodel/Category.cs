using System.ComponentModel.DataAnnotations;

namespace Hamoj.DB.Datamodel
{
    public class Category : basemodel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Image { get; set; }

        public List<Product> ProductList { get; set; } = new List<Product>();
    }
}
