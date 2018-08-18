using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using TVPIC.Models;

namespace TVPIC.DB
{
    public class DBMenu
    {
        public DataSet GetUserMenu(int UserID, int RoleID)
        {
            var ds = new DataSet();
            using (SqlConnection con = new SqlConnection(Common.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetUserMenu", con))
                {
                    cmd.Parameters.AddWithValue("@userid", UserID);
                    cmd.Parameters.AddWithValue("@roleid", RoleID);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }
            return ds;
        }
    }
}