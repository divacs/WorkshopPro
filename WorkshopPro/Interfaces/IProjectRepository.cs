using WorkshopPro.Model;

namespace WorkshopPro.Interfaces
{
    public interface IProjectRepository
    {
        ICollection<Project> GetProjects();
        Project GetProject(int id);
        Project GetProject(string name);
        bool ProjectExists(int id);
    }
}
