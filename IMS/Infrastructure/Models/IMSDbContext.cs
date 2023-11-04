using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IMS.Models
{
    public class IMSDbContext: DbContext
    {

        public IMSDbContext(DbContextOptions<IMSDbContext> 
            options) : base(options)
        {   

        }

        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Category> Category { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((AuditableEntity)entityEntry.Entity).ModifiedAt = DateTime.Now;
                ((AuditableEntity)entityEntry.Entity).ModifiedBy = "MyOnlyUser";

                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditableEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
                    ((AuditableEntity)entityEntry.Entity).CreatedBy = "MyOnlyUser";
                }

            }

            return base.SaveChanges();
        }

        

    }
}
