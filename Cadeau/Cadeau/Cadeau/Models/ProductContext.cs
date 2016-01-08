using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cadeau.Models
{
    public class ProductContext:DbContext
    {
        public ProductContext()
            :base("CadeauConnection")
        {

        }

        public DbSet<Product> Products { get; set; }

        public System.Data.Entity.DbSet<Cadeau.Models.Adres> Adres { get; set; }
    }
}