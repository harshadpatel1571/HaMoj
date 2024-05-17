using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamoj.DB.Datamodel
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int Prod_Id { get; set; }
        public string Prod_Name { get; set; }
        public int Prod_Price { get; set; }
        public string Prod_Image { get; set; }
        public int Qty { get; set; }
        public string Cust_Name { get; set; }
        public string Cust_Address { get; set; }
        public string Cust_City { get; set; }
        public int Create_Pincode { get; set; }
        public string Order_Status { get; set; }
        public int Create_by { get; set; }
        public DateTime Create_Date { get; set; }
        public int Modified_by { get; set; }
        public DateTime Modified_Date { get; set; }
        public byte is_Active { get; set; }
        public byte is_Delete { get; set; }


    }
}
