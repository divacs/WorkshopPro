using WorkshopPro.Data;
using WorkshopPro.Interfaces;
using WorkshopPro.Model;

namespace WorkshopPro.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private DataContext _context;

        public ProjectRepository(DataContext context)
        {
            _context = context;
        }

        public Project GetProject(int id)
        {
            return _context.Projects.Where(p => p.ProjectId == id).FirstOrDefault();
        }

        public Project GetProject(string name)
        {
            return _context.Projects.Where(p => p.Name == name).FirstOrDefault();
        }

        public ICollection<Project> GetProjects()
        {
            return _context.Projects.OrderBy(p => p.ProjectId).ToList();
        }

        public bool ProjectExists(int id)
        {
            return _context.Projects.Any(p => p.ProjectId == id);
        }
    }
}
