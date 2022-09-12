using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Context
{
    public class MetroContext : DbContext
    {
        public MetroContext(DbContextOptions<MetroContext> options) : base(options) { }
        public DbSet<Waste> Wastes { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<WasteType> WasteTypes { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Company> Companies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>()
                .HasData(
                    new Store
                    {
                        Id = 1,
                        Name = "Test  Mağaza 1"
                    },
                    new Store
                    {
                        Id = 2,
                        Name = "Test Mağaza 2"
                    }
                );
            modelBuilder.Entity<WasteType>()
                .HasData(
                    new WasteType
                    {
                        Id = 1,
                        Name = "Atık Tipi 1"
                    },
                    new WasteType
                    {
                        Id = 2,
                        Name = "Atık Tipi 2"
                    }
                );
            modelBuilder.Entity<WasteKind>()
                .HasData(
                    new WasteKind
                    {
                        Id = 1,
                        Name = "Atık Çeşidi 1"
                    },
                    new WasteKind
                    {
                        Id = 2,
                        Name = "Atık Çeşidi 2"
                    }
                );
            modelBuilder.Entity<Company>()
                .HasData(
                    new WasteType
                    {
                        Id = 1,
                        Name = "Şirket 1"
                    },
                    new WasteType
                    {
                        Id = 2,
                        Name = "Şirket"
                    }
                );
            modelBuilder.Entity<Unit>()
                .HasData(
                    new Unit
                    {
                        Id = 1,
                        Name = "KG"
                    },
                    new Unit
                    {
                        Id = 2,
                        Name = "Adet"
                    }
                );
            modelBuilder.Entity<Waste>()
                .HasData(
                    new Waste
                    {
                        Id = 1,
                        WasteKindId = 1,
                        UnitId = 1,
                        WasteDate = DateTime.Now,
                        WasteTypeId = 1,
                        Month = Core.Enums.Month.Agustos,
                        DeliveryCompanyId = 1,
                        IsActive = true,
                        Quantity = 5,
                        StoreId = 1
                    },
                    new Waste
                    {
                        Id = 2,
                        WasteKindId = 2,
                        UnitId = 2,
                        WasteDate = DateTime.Now,
                        WasteTypeId = 2,
                        Month = Core.Enums.Month.Agustos,
                        DeliveryCompanyId = 2,
                        IsActive = true,
                        Quantity = 6,
                        StoreId = 2
                    }
                );
        }
    }
}
