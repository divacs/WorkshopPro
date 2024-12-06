namespace WorkshopPro.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirdth { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public Workshop Workshop { get; set; }
        //public int? ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
