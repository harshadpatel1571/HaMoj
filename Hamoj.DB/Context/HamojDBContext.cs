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
        public DbSet<VendorProduct> VendorProduct { get; set; }
        public DbSet<UserRights> UserRights { get; set; }
        public DbSet<Customer> Customer {  get; set; }
        public DbSet<OrderDetails> OrderDetails {  get; set; }

        public DbSet<VendorUser> VendorUsers { get; set; }


    }
}
