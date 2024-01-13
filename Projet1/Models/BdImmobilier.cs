using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace Projet1.Models
{
    public class BdImmobilier: DbContext
    {
        public BdImmobilier(): base("conImmobilier") { }
        public DbSet<User> users { get; set; }
        public DbSet<Bien> biens { get; set; }
        public DbSet<Proprietaire> proprietaires { get; set; }
        public DbSet<Maison> maisons { get; set; }
        public DbSet<Appartement> appartements { get; set; }
        public DbSet<Studio> studios { get; set; }
        public DbSet<Terrain> terrains { get; set; }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Définissez l'association de composition faible entre Maison et Appartement
            modelBuilder.Entity<Maison>()
                .HasMany(m => m.ListeAppartements)
                .WithOptional(a => a.Maison)  // Utilisation de WithOptional pour indiquer la clé étrangère nullable
                .HasForeignKey(a => a.MaisonId)
                .WillCascadeOnDelete(false);   // Ne pas supprimer automatiquement les Appartements lorsqu'une Maison est supprimée

            //L'association de composition faible entre Maison et Studio
            modelBuilder.Entity<Maison>()
                .HasMany(m => m.ListeStudios)
                .WithOptional(a => a.Maison)  // Utilisation de WithOptional pour indiquer la clé étrangère nullable
                .HasForeignKey(a => a.MaisonId)
                .WillCascadeOnDelete(false);
        }*/

    }
}