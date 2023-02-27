using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataContext
{
    public class Context : DbContext
    {
        public DbSet<StorageType> StorageTypes { get; set; }
        public DbSet<StorageLocation> StorageLocations { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<TransferOrder> TransferOrders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }
    }
}
