using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tutorial2Session4.Models;

namespace Tutorial2Session4.Controllers
{
    public class JohnController : Controller
    {
        private SchoolContext schoolDb = new SchoolContext();

        // GET: John
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string firstname, string lastname, string res, DateTime enrollmentdate)
        {
            Student s = new Student();
            s.FirstMidName = firstname;
            s.LastName = lastname;
            s.ResidenceHall = res;
            s.EnrollmentDate = enrollmentdate;

            // SchoolContext schoolDb = new SchoolContext();
            schoolDb.Students.Add(s);
            schoolDb.SaveChanges();
            return View(s);
        }
    }
}