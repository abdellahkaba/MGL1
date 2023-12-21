namespace Projet1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Projet1.Models.BdImmobilier>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false; 
        }

        protected override void Seed(Projet1.Models.BdImmobilier context)
        {
            
        }
    }
}
