using WorkshopPro.Model;

namespace WorkshopPro.Interfaces
{
    public interface IMaterialRepository
    {
        ICollection<Material> GetMaterials();
        Material GetMaterial(int id);
        int GetMaterialQuantity(string name);
        int GetMaterialPrice(string name);
        bool MaterialExists(int id); // checking if material with certan id exists

    }
}
