using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BaseContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<RepairPart> RepairParts { get; set; }

        public BaseContext()
            : base("Base")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RepairPart>().HasKey(rp => new { rp.ComponentId, rp.RepairId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
