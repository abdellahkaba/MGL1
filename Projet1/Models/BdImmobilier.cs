using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projet1.Models
{
    public class BdImmobilier: DbContext
    {
        public BdImmobilier(): base("conImmobilier") { }

        public DbSet<Bien> bien { get; set; }
        public DbSet<Maison> maison { get; set; }

        public DbSet<Proprietaire> proprietaire { get; set; }
    }
}