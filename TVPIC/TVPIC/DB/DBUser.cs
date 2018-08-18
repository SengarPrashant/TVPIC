using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using TVPIC.Models;


namespace TVPIC.DB
{
    public class DBUser
    {
        
        public User GetUserByUserName(string username)
        {
            var dt = new DataTable();
            var user = new User();
            using (SqlConnection con = new SqlConnection(Common.connectionString))
            {
                using(SqlCommand cmd=new SqlCommand("Select um.*,r.RoleName from UserMaster um join RoleMaster r on um.RoleID=r.RoleID where UserName=@un", con))
                {
                    cmd.Parameters.AddWithValue("@un", username);
                    using(SqlDataAdapter da=new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                user.UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                user.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                user.MiddleName = Convert.ToString(dt.Rows[0]["MiddleName"]);
                user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                user.RoleID = Convert.ToInt32(dt.Rows[0]["RoleID"]);
                user.RoleName = Convert.ToString(dt.Rows[0]["RoleName"]);
                user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                user.Phone = Convert.ToString(dt.Rows[0]["Phone"]);
                user.Password = Convert.ToString(dt.Rows[0]["Password"]);
                user.ActiveStatus=  Convert.ToInt32(dt.Rows[0]["ActiveStatus"]);
                user.UserImage = Convert.ToString(dt.Rows[0]["UserImage"]);
            }
            return user;
        }
    }
}