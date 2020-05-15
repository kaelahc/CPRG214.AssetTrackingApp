using CPRG214.Assets.Domain;
using Microsoft.EntityFrameworkCore;

namespace CPRG214.Assets.Data
{
    public class AssetContext : DbContext
    {
        // Context which calls the base class constructor.
        public AssetContext() : base() { }

        // Collection properties for the Domain properties.
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }

        // Method which provides connection to the Sql Server instance
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\sqlexpress;Database=Assets;Trusted_Connection=True;");
        }

        // Seed data in both Assets and AssetTypes tables.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AssetType>().HasData(
                new AssetType { Id = 1, Name = "Computer" },
                new AssetType { Id = 2, Name = "Monitor" },
                new AssetType { Id = 3, Name = "Phone" }
                );

            modelBuilder.Entity<Asset>().HasData(
                new Asset
                {
                    Id = 1,
                    TagNumber = "a12b",
                    AssetTypeId = 1,
                    Manufacturer = "Dell",
                    Model = "G5420",
                    Description = "Inspiron Small Desktop",
                    SerialNumber = "a12bg5420"
                },
                new Asset
                {
                    Id = 2,
                    TagNumber = "c34d",
                    AssetTypeId = 2,
                    Manufacturer = "Acer",
                    Model = "EB2",
                    Description = "Classic Full HD Monitor",
                    SerialNumber = "c34deb2"
                },
                new Asset
                {
                    Id = 3,
                    TagNumber = "e56f",
                    AssetTypeId = 3,
                    Manufacturer = "Cisco",
                    Model = "IP8800",
                    Description = "IP Phone 8800 Series",
                    SerialNumber = "e56fip8800"
                }
                );
        }
    }
}
