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
            for (int i = 0; i < id; i++)
            {
                ExecutionManager.RunSim();
            }
            string state = "Time: " + World.Time + "\n\n" + AgentManager.SerializeAllAgents();
            return state;
        }
    }
}
