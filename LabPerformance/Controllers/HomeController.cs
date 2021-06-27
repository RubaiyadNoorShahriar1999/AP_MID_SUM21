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
            Student s = new Student();
            return View(s);
        }
        public ActionResult Registration()
        {
            Student p = new Student();
            return View(p);
        }
        [HttpPost]
        public ActionResult Registration(Student p)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Students.Insert(p);
                return RedirectToAction("Index");
            }
            return View();

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
       

        public ActionResult Student(Student s )
        {
            return View(s);
        }
        public ActionResult Edit(int id)
        {

            Database db = new Database();
            var p = db.Students.Get(id);

            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(Student p)
        {

            Database db = new Database();
            db.Students.Update(p);
            return RedirectToAction("Index");
        }
    }
}