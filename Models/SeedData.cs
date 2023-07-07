using System.ComponentModel.Design.Serialization;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.People.Any() && !context.Departments.Any() && !context.Locations.Any())
            {
                var d1 = new Department { Name = "Sales" };
                var d2 = new Department { Name = "Development" };
                var d3 = new Department { Name = "Support" };
                var d4 = new Department { Name = "Facilities" };
                context.Departments.AddRange(d1, d2, d3, d4);
                context.SaveChanges();
                var l1 = new Location { City = "Oakland", State = "CA" };
                var l2 = new Location { City = "San Jose", State = "CA" };
                var l3 = new Location { City = "New York", State = "NY" };
                context.Locations.AddRange(l1, l2, l3);

                context.People.AddRange(new Person
                {
                    FirstName = "Francesca",
                    Surname = "Jacobs",
                    Department = d2,
                    Location = l1
                },
                    new Person
                    {
                        FirstName = "Charles",
                        Surname = "Fuentes",
                        Department = d2,
                        Location = l3
                    },
                    new Person
                    {
                        FirstName = "Bright",
                        Surname = "Becker",
                        Department = d4,
                        Location = l1
                    },
                    new Person
                    {
                        FirstName = "Murphy",
                        Surname = "Lara",
                        Department = d1,
                        Location = l3
                    },
                    new Person
                    {
                        FirstName = "Beasley",
                        Surname = "Hoffman",
                        Department = d4,
                        Location = l3
                    },
                    new Person
                    {
                        FirstName = "Marks",
                        Surname = "Hays",
                        Department = d4,
                        Location = l1
                    },
                    new Person
                    {
                        FirstName = "Underwood",
                        Surname = "Trujillo",
                        Department = d2,
                        Location = l1
                    },
                    new Person
                    {
                        FirstName = "Randall",
                        Surname = "Lloyd",
                        Department = d3,
                        Location = l2
                    },
                    new Person
                    {
                        FirstName = "Guzman",
                        Surname = "Case",
                        Department = d2,
                        Location = l2
                    });
                context.SaveChanges();
            }
        }
    }
}
