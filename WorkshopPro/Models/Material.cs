namespace WorkshopPro.Model
{
    public class Material
    {
        public int MaterialId { get; set; }
        public string Name { get; set; }
        public int StockQuantity { get; set; }  // Stock count
        public decimal UnitPrice { get; set; } // price per unit
        public ICollection<ProjectMaterial> ProjectMaterials { get; set; }
    }
}
