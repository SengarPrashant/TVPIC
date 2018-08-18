using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TVPIC.Models;

namespace TVPIC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(FormCollection obj)
        {
            ViewBag.Message = "";
            var username = Convert.ToString(obj["txtUserID"]).Trim();
            var pass = Convert.ToString(obj["txtPassword"]).Trim();
            User user = new User();
            user = user.ValidateUser(username, pass);
            if (user.Message == "")
            {
                Common.UserSession = user;
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                ViewBag.Message = user.Message;
            }
            return View("Login");
        }
        public ActionResult Logout()
        {
            Common.UserSession = null;
            return RedirectToAction("Index", "Home");
        }
    }
}