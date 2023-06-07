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
        public string Step(int id)
        {
            ExecutionManager.RunSim(id);
            string state = "Time: " + World.Time + "\n\n" + AgentManager.SerializeAllAgents();
            return state;
        }
    }
}
