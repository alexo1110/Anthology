using Anthology.Models;
using Microsoft.AspNetCore.Mvc;

namespace Anthology.Controllers
{
    public class ActionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Action/Print/
        public string Print()
        {
            string test = ActionManager.SerializeAllActions();
            return test;
        }
    }
}
