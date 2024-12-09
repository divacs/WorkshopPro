using Microsoft.VisualBasic;
using WorkshopPro.Data;
using WorkshopPro.Interfaces;
using WorkshopPro.Model;

namespace WorkshopPro.Repository
{
    public class MaterialRepository : IMaterialRepository
    {
        private DataContext _context;
        public MaterialRepository(DataContext context)
        {
            _context = context;
        }
        public Material GetMaterial(int id)
        {
            return _context.Materials.Where(m => m.MaterialId == id).FirstOrDefault();    
        }

        public int GetMaterialPrice(string name)
        {
            throw null;
        }

        public int GetMaterialQuantity(string name)
        {          
            throw null;
        }

        public ICollection<Material> GetMaterials()
        {
            return _context.Materials.OrderBy(m => m.MaterialId).ToList();
        }
        public bool MaterialExists(int id)
        {
            return _context.Materials.Any(e => e.MaterialId == id);
        }
    }
}
