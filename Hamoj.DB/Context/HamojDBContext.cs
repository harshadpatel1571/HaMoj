using Hamoj.DB.Datamodel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamoj.DB.Context
{
    public class HamojDBContext : DbContext
    {
        public HamojDBContext(DbContextOptions<HamojDBContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }

        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<VendorProduct> Vendor_Product { get; set; }
        public DbSet<UserRights> UserRights { get; set; }

    }
}
