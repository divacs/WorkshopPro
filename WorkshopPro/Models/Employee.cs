namespace WorkshopPro.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public Workshop Workshop { get; set; }
        //public int? ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
