using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WorkshopPro.Model
{
    public class Workshop
    {
        public int WorkshopId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime OpeningDate { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
