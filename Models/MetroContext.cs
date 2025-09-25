using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Intergrated_Project.Models
{
    public class MetroContext : DbContext
    {
       
            public MetroContext() : base("MetroDatabase") { }
            
            public DbSet<User> Users { get; set; }
        public DbSet<Officers> Police { get; set; }


    }
}