using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TVPIC.DB;
using TVPIC.Models;

namespace TVPIC.Models
{
    public class User
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + MiddleName + " " + LastName; } }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int ActiveStatus { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
        public string UserImage { get; set; }
        public User ValidateUser(string username,string Password)
        {
            var db = new DBUser();
            var user= db.GetUserByUserName(username);
            if(user.UserID==0)
            {
                user.Message = "Invalid User Name.";
            }
            else if (user.Password != Password)
            {
                user.Message = "Invalid Password.";
            }
            else if(user.ActiveStatus==0)
            {
                user.Message = "Inactive user. Please contact your system administrator.";
            }
            else if (user.ActiveStatus == 2)
            {
                user.Message = "User Id is blocked. Please contact your system administrator.";
            }
            else
            {
                user.Message = "";
            }
            return user;
        }
        public DataSet GetUserMenu(int UserID, int RoleID)
        {
            var db = new DBMenu();
            return db.GetUserMenu(UserID, RoleID);
        }
    }
    
}