using Anthology.Models;
using Microsoft.AspNetCore.Mvc;

namespace Anthology.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Location/Print/
        public string Print()
        {
            string test = LocationManager.SerializeAllLocations();
            return test;
        }
    }
}
