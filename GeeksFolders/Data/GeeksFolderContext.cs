using GeeksFolders.Models;
using Microsoft.EntityFrameworkCore;

namespace GeeksFolders.Data
{
    public class GeeksFolderContext : DbContext
    {
        public GeeksFolderContext(DbContextOptions<GeeksFolderContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeekFolder>()
                .HasOne(f => f.Parent)
                .WithMany(f => f.Children)
                .HasForeignKey(f => f.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Unique constraint to ensure each child's name is unique withing its parent
            modelBuilder.Entity<GeekFolder>()
                .HasIndex(f => new { f.ParentId, f.Name })
                .IsUnique();
        }

        public DbSet<GeekFolder> GeekFolders { get; set; }
    }
}
