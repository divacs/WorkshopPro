using WorkshopPro.Model;

namespace WorkshopPro.DTO
{
    public class MaterialDto
    {
        public int MaterialId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }  // Stock count
        public int UnitPrice { get; set; } // price per unit
    }
}
