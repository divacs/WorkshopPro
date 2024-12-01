namespace WorkshopPro.Model
{
    public class Material
    {
        public int MaterialId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }  // Stock count
        public int UnitPrice { get; set; } // price per unit
        public ICollection<ProjectMaterial> ProjectMaterials { get; set; }
    }
}
