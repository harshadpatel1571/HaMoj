using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamoj.DB.Datamodel
{
    public  class UserRights
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; }
        public string MenuName { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public int Create_by { get; set; }
        public DateTime Create_Date { get; set; }
        public int Modified_by { get; set; }
        public DateTime Modified_Date { get; set; }
        public byte is_Active { get; set; }
        public byte is_Delete { get; set; }
    }
}
