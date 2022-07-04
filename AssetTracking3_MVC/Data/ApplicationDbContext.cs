using AssetTracking3_MVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AssetTracking3_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Office> Offices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AssetItem> Assetitems { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}