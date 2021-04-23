using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace FuelProject.Models
{
    public class FuelBaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tank> Tanks { get; set; }
        public DbSet<FuelDailyStatement> FuelDailyStatements { get; set; }
        public DbSet<InventoryFuel> InventoryFuels { get; set; }
        public DbSet<InventoryGSM> InventoryGSMs { get; set; }
    }
}