
using System.ComponentModel.DataAnnotations;


namespace Hamoj.DB.Datamodel;

public class VendorProduct : basemodel
{
    [Key]
    public int VendorID { get; set;}
    public int ProductID { get; set;}

}
