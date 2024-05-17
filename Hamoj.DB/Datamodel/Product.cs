﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamoj.DB.Datamodel
{
    public class Product
    {
        public int Id { get; set; }

        public string Category { get; set; }
        public string Name { get; set; }    
        public int Price { get; set; }    
        public string Description { get; set; }    
        public string Image { get; set; }
        public int Create_by { get; set; }
        public DateTime Create_Date { get; set; }
        public int Modified_by { get; set; }
        public DateTime Modified_Date { get; set; }
        public byte is_Active { get; set; }
        public byte is_Delete { get; set; }
    }
}
