using System;
using System.Collections.Generic;
using System.Linq;
using WorkshopPro.Data;
using WorkshopPro.Model;

namespace WorkshopPro
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedDataContext()
        {
            if (!_context.Workshops.Any())
            {
                // Dodavanje radionica
                var workshops = new List<Workshop>
                {
                    new Workshop 
                    { 
                        Name = "Metal Workshop", 
                        Location = "Building A", 
                        OpeningDate = new DateTime(2000, 1, 1) 
                    },
                    new Workshop 
                    { 
                        Name = "Wood Workshop", 
                        Location = "Building B", 
                        OpeningDate = new DateTime(2005, 6, 15) 
                    },
                    new Workshop 
                    { 
                        Name = "Painting Workshop", 
                        Location = "Building C", 
                        OpeningDate = new DateTime(2010, 3, 20) 
                    },
                    new Workshop 
                    { 
                        Name = "Electronics Workshop", 
                        Location = "Building D", 
                        OpeningDate = new DateTime(2018, 9, 5) 
                    }
                };

                _context.Workshops.AddRange(workshops);
            }

            if (!_context.Employees.Any())
            {
                // Dodavanje zaposlenih
                var employees = new List<Employee>
                {
                    new Employee
                    {
                        FirstName = "Alice",
                        LastName = "Johnson",
                        Position = "Engineer",
                        Salary = 70000,
                        Workshop = _context.Workshops.FirstOrDefault(w => w.Name == "Metal Workshop")
                    },
                    new Employee
                    {
                        FirstName = "Bob",
                        LastName = "Smith",
                        Position = "Technician",
                        Salary = 50000,
                        Workshop = _context.Workshops.FirstOrDefault(w => w.Name == "Wood Workshop")
                    },
                    new Employee
                    {
                        FirstName = "Charlie",
                        LastName = "Brown",
                        Position = "Painter",
                        Salary = 45000,
                        Workshop = _context.Workshops.FirstOrDefault(w => w.Name == "Painting Workshop")
                    },
                    new Employee
                    {
                        FirstName = "Diana",
                        LastName = "Prince",
                        Position = "Electrician",
                        Salary = 60000,
                        Workshop = _context.Workshops.FirstOrDefault(w => w.Name == "Electronics Workshop")
                    }
                };

                _context.Employees.AddRange(employees);
            }

            if (!_context.Projects.Any())
            {
                // Dodavanje projekata
                var projects = new List<Project>
                {
                    new Project
                    {
                        Name = "Bridge Construction",
                        Deadline = DateTime.Now.AddMonths(6),
                        Description = "Build a modern bridge"
                    },
                    new Project
                    {
                        Name = "School Renovation",
                        Deadline = DateTime.Now.AddMonths(3),
                        Description = "Renovate old school building"
                    },
                    new Project
                    {
                        Name = "Apartment Wiring",
                        Deadline = DateTime.Now.AddMonths(2),
                        Description = "Install electrical wiring in apartments"
                    },
                    new Project
                    {
                        Name = "Furniture Production",
                        Deadline = DateTime.Now.AddMonths(5),
                        Description = "Produce wooden furniture"
                    }
                };

                _context.Projects.AddRange(projects);
            }

            if (!_context.Materials.Any())
            {
                // Dodavanje materijala
                var materials = new List<Material>
                {
                    new Material { Name = "Steel", Quantity = 100, UnitPrice = 500000 },
                    new Material { Name = "Wood", Quantity = 200, UnitPrice = 300000 },
                    new Material { Name = "Concrete", Quantity = 150, UnitPrice = 75000000 },
                    new Material { Name = "Paint", Quantity = 50, UnitPrice = 200000 },
                    new Material { Name = "Cables", Quantity = 300, UnitPrice = 1000000000 }
                };

                _context.Materials.AddRange(materials);
            }

            if (!_context.ProjectMaterials.Any())
            {
                // Dodavanje many-to-many veza između projekata i materijala
                var projectMaterials = new List<ProjectMaterial>
                {
                    new ProjectMaterial { ProjectId = 1, MaterialId = 1 }, // Bridge uses Steel
                    new ProjectMaterial { ProjectId = 1, MaterialId = 3 }, // Bridge uses Concrete
                    new ProjectMaterial { ProjectId = 2, MaterialId = 2 }, // School uses Wood
                    new ProjectMaterial { ProjectId = 2, MaterialId = 4 }, // School uses Paint
                    new ProjectMaterial { ProjectId = 3, MaterialId = 5 }, // Wiring uses Cables
                    new ProjectMaterial { ProjectId = 4, MaterialId = 2 }, // Furniture uses Wood
                    new ProjectMaterial { ProjectId = 4, MaterialId = 4 }  // Furniture uses Paint
                };

                _context.ProjectMaterials.AddRange(projectMaterials);
            }

            // Čuvanje promena u bazi
            _context.SaveChanges();
        }
    }
}
