using Anthology.Models;
using Microsoft.AspNetCore.Mvc;

namespace Anthology.Controllers
{
    public class TempSimController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // GET: /TempSim/Step/
        public string Step()
        {
            ExecutionManager.RunSim();
            return "Time: " + World.Time;
        }
    }
}
