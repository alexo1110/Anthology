﻿using Anthology.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Anthology.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ExecutionManager.Init();
            ActionManager.LoadActionsFromFile("Data\\Actions.json");
            AgentManager.LoadAgentsFromFile("Data\\Agents.json");
            LocationManager.LoadLocationsFromFile("Data\\Locations.json");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}