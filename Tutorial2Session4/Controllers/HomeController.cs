using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tutorial2Session4.Models;

namespace Tutorial2Session4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SchoolContext db = new SchoolContext();
            db.Students.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}