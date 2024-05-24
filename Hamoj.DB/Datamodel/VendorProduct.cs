using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamoj.DB.Datamodel
{
    public class VendorProduct
    {
        [Key]
        public int VendorID { get; set;}
        public int ProductID { get; set;}

        public int Create_by { get; set; }
        public DateTime Create_Date { get; set; }
        public int? Modified_by { get; set; }
        public DateTime? Modified_Date { get; set; }
        public byte is_Active { get; set; }
        public byte is_Delete { get; set; }
    }
}
