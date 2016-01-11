using Microsoft.Data.Entity;
using System;

namespace TheWorld.Models
{
    public class WorldContext : DbContext
    {
        public WorldContext() {
            Database.EnsureCreated();
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Stop> Stops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = "Data Source=ISOLATEDX35\\MSSQL2014;Initial Catalog=TheWorld;User ID=ehsan;Password=$Ehsan5505";
            //var connString = "Server=(LocalDB)\v11.0;Initial File Name=|DataDirectory|\DatabaseFileName.mdf;Database=WorldTour;Trusted_Connection=True;MultipleActiveResultSets=True";
            optionsBuilder.UseSqlServer(connString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
