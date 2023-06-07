using Microsoft.AspNetCore.Mvc;
using Anthology.Models;
using System.Text.Json;

namespace Anthology.Controllers
{
    public class AgentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Agent/Print/
        public string Print()
        {
            string test = AgentManager.SerializeAllAgents();
            return test;
        }
    }
}
