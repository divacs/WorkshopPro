namespace WorkshopPro.Model
{
    public class ProjectMaterial
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public int QuantityUsed { get; set; }
    }
}
