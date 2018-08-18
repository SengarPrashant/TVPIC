using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TVPIC.Models
{
    public static class Common
    {
        public static User UserSession {
            get {
                if(HttpContext.Current.Session["User"]==null)
                { return null; }
                else
                {
                  return (User)HttpContext.Current.Session["User"];
                }
            }
            set {
                HttpContext.Current.Session["User"] = value;
            }
        }
        public static string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    }
    public enum ActiveKey
    {
        InActive = 0,
        Active = 1,
        Blocked = 2,
        Terminated = 3
    }
}