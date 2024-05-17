using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamoj.DB.Datamodel
{
    public class Order
    {
        public int ID { get; set; }

        public int Cust_Id { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public int Gst { get; set; }
        public int Amout { get; set; }
        public int Create_by { get; set; }
        public DateTime Create_Date { get; set; }
        public int Modified_by { get; set; }
        public DateTime Modified_Date { get; set; }
        public byte is_Active { get; set; }
        public byte is_Delete { get; set; }
    }
}
