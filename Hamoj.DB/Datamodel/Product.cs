

namespace Hamoj.DB.Datamodel;

public class Product : basemodel
{
    public int Id { get; set; }

    public string Category { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public string? Image { get; set; }

}
