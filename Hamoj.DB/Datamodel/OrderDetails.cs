

namespace Hamoj.DB.Datamodel;

public class OrderDetails : basemodel
{
    public int Id { get; set; }
    public int Prod_Id { get; set; }
    public string Prod_Name { get; set; }
    public int Prod_Price { get; set; }
    public string? Prod_Image { get; set; }
    public int Qty { get; set; }
    public string Cust_Name { get; set; }
    public string Cust_Address { get; set; }
    public string Cust_City { get; set; }
    public int Create_Pincode { get; set; }
    public string Order_Status { get; set; }


}
