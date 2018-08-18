using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using TVPIC.Models;

namespace TVPIC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public PartialViewResult MenuItem()
        {
            var u = new User();
            int userid = Common.UserSession == null ? 0 : Common.UserSession.UserID;
            int roleid= Common.UserSession == null ? 0 : Common.UserSession.RoleID;
            var ds = u.GetUserMenu(userid,roleid);
            ViewBag.Menu = ds.Tables[0];
            ViewBag.MenuItem = ds.Tables[1];
            ViewBag.UserName = Common.UserSession == null ? "" : Common.UserSession.FullName;
            ViewBag.Image= Common.UserSession == null ? "" : "../UserImage/" + Common.UserSession.UserImage;
            return PartialView("Menu");
        }
    }
}