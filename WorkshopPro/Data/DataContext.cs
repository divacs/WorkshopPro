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
    }
}
