

namespace Hamoj.DB.Datamodel;

public class Order : basemodel
{
    public int ID { get; set; }

    public int Cust_Id { get; set; }
    public string Name { get; set; }
    public int Qty { get; set; }
    public int Gst { get; set; }
    public int Amount { get; set; }

}
