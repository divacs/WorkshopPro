namespace WorkshopPro.Model
{
    public class Project
    {
        public int ProjectId { get; set; }
        public decimal Name { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<ProjectMaterial> ProjectMaterials { get; set; }
    }
}
