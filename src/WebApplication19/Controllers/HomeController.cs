using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication19.Models;

namespace WebApplication19.Controllers
{
    public class HomeController : Controller
    {
        public int Add(int a, int b)
        {
            return a + b;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            if (false)
            {
                return NotFound();
            }

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Studenten()
        {
            List<Student> studentenLijst = new List<Student>()
            {
                new Student() { Id=1, Name = "Bert"},
                new Student() { Id=5, Name = "Ernie"}
            };

            return View(studentenLijst);
        }

        [HttpPost]
        public IActionResult Edit(Student s)
        {
            if (ModelState.IsValid)
                //hier hoort nog eigenlijk wegschrijven naar Db
                return RedirectToAction("Index");
            else
                return View(s);
        }

    }
}
