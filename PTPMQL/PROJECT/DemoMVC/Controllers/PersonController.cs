using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Person ps)
        {
            string strOutput = "Hello " + ps.PersonID + " Name " + ps.FullName + " O " + ps.Address;
            ViewBag.Message = strOutput;
            ViewData["Message"] = strOutput;
            return View();

        }
    } }