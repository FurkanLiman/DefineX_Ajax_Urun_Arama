using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AjaxUrunArama.Models
{
    public class ProductContext : DbContext
    {
        // Web.config'deki "DefaultConnection" ile eşleşmeli
        public ProductContext() : base("DefaultConnection")
        {
        }

        // Veritabanında Products tablosu
        public DbSet<Product> Products { get; set; }
    }
}