using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IMS.Models
{
    public class IMSDbContext: IdentityDbContext
    {

        public IMSDbContext(DbContextOptions<IMSDbContext> 
            options) : base(options)
        { 
        }

        public DbSet<InventoryItem> InventoryItems { get; set; }

    }
}
