

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hamoj.DB.Datamodel;

public class Product : basemodel
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public string? Image { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }
}
