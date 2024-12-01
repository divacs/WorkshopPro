using Microsoft.EntityFrameworkCore;
using WorkshopPro.Model;

namespace WorkshopPro.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<ProjectMaterial> ProjectMaterials { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite Key for ProjectMaterial
            modelBuilder.Entity<ProjectMaterial>()
                .HasKey(pm => new { pm.ProjectId, pm.MaterialId });

            // Relationship: ProjectMaterial -> Project
            modelBuilder.Entity<ProjectMaterial>()
                .HasOne(pm => pm.Project) // Navigation property in ProjectMaterial
                .WithMany(p => p.ProjectMaterials) // Navigation property in Project
                .HasForeignKey(pm => pm.ProjectId); // FK in ProjectMaterial points to ProjectId

            // Relationship: ProjectMaterial -> Material
            modelBuilder.Entity<ProjectMaterial>()
                .HasOne(pm => pm.Material) // Navigation property in ProjectMaterial
                .WithMany(m => m.ProjectMaterials) // Navigation property in Material
                .HasForeignKey(pm => pm.MaterialId); // FK in ProjectMaterial points to MaterialId
        }
    }

}
