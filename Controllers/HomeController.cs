using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class PeopleListViewModel
    {
        public IEnumerable<Person> People { get; set; } = Enumerable.Empty<Person>();
        public IEnumerable<string> Cities { get; set; } = Enumerable.Empty<string>();
        public string SelectedCity { get; set; } = string.Empty;

        public string GetClass(string? city) => SelectedCity == city ? "background-color:black;" : "";
        

    }

    public class HomeController : Controller
    {
        private readonly DataContext context;

        public HomeController(DataContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index([FromQuery] string selectedCity)
        {
            return View(new PeopleListViewModel
            {
                People = context.People.Include(p => p.Department).Include(p => p.Location),
                Cities = context.Locations.Select(l => l.City).Distinct(),
                SelectedCity = selectedCity
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}