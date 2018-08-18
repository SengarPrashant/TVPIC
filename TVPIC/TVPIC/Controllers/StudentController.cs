using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TVPIC.Models;

namespace TVPIC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Registration()
        {
            Masters masters = new Masters();
            ViewBag.Class = masters.FillClass();
            return View();
        }
    }
}