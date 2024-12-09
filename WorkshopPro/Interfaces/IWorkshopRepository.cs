using WorkshopPro.Model;

namespace WorkshopPro.Interfaces
{
    public interface IWorkshopRepository
    {
        ICollection<Workshop> GetWorkshops();
        Workshop GetWorkshop(int id);
        Workshop GetWorkshop(string name);
        Workshop GetWorkshopByLocation(string location);
        bool WorkshopExists(int id);
    }
}
