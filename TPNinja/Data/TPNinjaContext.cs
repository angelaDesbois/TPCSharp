﻿using BO;
using BOTP6;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TPNinja.Data
{
    public class TPNinjaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TPNinjaContext() : base("name=TPNinjaContext")
        {
        }

        public System.Data.Entity.DbSet<BOTP6.Samourai> Samourais { get; set; }

        public System.Data.Entity.DbSet<BOTP6.Arme> Armes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
           modelBuilder.Entity<Samourai>().HasOptional(a => a.Arme).WithOptionalPrincipal();
           modelBuilder.Entity<Samourai>().HasMany(x => x.artMartials).WithMany();
        }

        public System.Data.Entity.DbSet<BO.ArtMartial> ArtMartials { get; set; }
    }
}
