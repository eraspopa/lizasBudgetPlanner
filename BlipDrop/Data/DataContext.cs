using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BlipDrop.Models;

namespace BlipDrop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("ApplicationDbContext")
        {

        }
        public DbSet<Record> Records { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Period> Periods { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}