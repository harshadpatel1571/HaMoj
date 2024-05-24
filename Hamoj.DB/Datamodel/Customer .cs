using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamoj.DB.Datamodel
{
    public class Customer
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
        public int  Pincode { get; set; }
        public int Create_by { get; set; }
        public DateTime Create_Date { get; set; }
        public int? Modified_by { get; set; }
        public DateTime? Modified_Date { get; set; }
        public byte is_Active { get; set; }
        public byte is_Delete { get; set; }

    }
}
