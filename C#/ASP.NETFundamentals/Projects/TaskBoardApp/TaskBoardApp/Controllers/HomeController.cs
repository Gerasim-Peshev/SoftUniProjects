using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskBoardApp.Models;

namespace TaskBoardApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("All", "Board");
            }
            return View();
        }
    }
}