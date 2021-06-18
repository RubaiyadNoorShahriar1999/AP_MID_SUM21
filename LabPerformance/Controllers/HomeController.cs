using LabPerformance.Models;
using LabPerformance.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabPerformance.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            student s = new student();
            return View(s);
        }

        public ActionResult Registration(string Name , string ID ,string DOB , string Credit ,string CGPA, string Dept_ID)
        {
            ViewData["Name"] = Name;
            ViewData["ID"] = ID;
            ViewData["Credit"] = Credit;
            ViewData["CGPA"] = CGPA;
            ViewData["Dept_ID"] = Dept_ID;

            return View();
        }
       

        public ActionResult Student(student s )
        {
            return View(s);
        }
    }
}