using System.ComponentModel.DataAnnotations;

namespace Hamoj.DB.Datamodel
{
    public class Category : basemodel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required !")]
        public string Name { get; set; }

        public string? Image { get; set; }


    }
}
