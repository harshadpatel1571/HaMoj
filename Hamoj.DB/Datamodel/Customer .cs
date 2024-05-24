
namespace Hamoj.DB.Datamodel;

public class Customer : basemodel
{
    public int Id { get; set; }
    public string CompanyName { get; set; }

    public int Office_No { get; set; }

    public string Name { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int Pincode { get; set; }


}
