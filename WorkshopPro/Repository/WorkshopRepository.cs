using WorkshopPro.Data;
using WorkshopPro.Interfaces;
using WorkshopPro.Model;

namespace WorkshopPro.Repository
{
    public class WorkshopRepository : IWorkshopRepository
    {
        private DataContext _context;

        public WorkshopRepository(DataContext context)
        {
            _context = context;
        }
        public Workshop GetWorkshop(string name)
        {
            return _context.Workshops.Where(w => w.Name == name).FirstOrDefault();
        }

        public Workshop GetWorkshop(int id)
        {
            return _context.Workshops.Where(w => w.WorkshopId == id).FirstOrDefault();
        }

        public Workshop GetWorkshopByLocation(string location)
        {
            return _context.Workshops.Where(w => w.Location == location).FirstOrDefault();
        }

        public ICollection<Workshop> GetWorkshops()
        {
            return _context.Workshops.OrderBy(w => w.WorkshopId).ToList();
        }

        public bool WorkshopExists(int id)
        {
            return _context.Workshops.Any(w => w.WorkshopId == id);
        }
    }
}
