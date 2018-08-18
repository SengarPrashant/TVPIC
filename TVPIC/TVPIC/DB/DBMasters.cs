using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using TVPIC.Models;

namespace TVPIC.DB
{
    public class DBMasters
    {
        #region SubjectMaster
        public DataTable FillSubjectData(int UserID, int RoleID)
        {
            var ds = new DataTable();
            using (SqlConnection con = new SqlConnection(Common.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Select ID, ('['+SubjectCode + '] ' + Subject) as DispText  from SubjectMaster where ActiveStatus=1 order by SubjectCode", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }
            return ds;
        }

        #endregion

        #region ClassMaster
        public DataTable FillClassData(int UserID, int RoleID)
        {
            var ds = new DataTable();
            using (SqlConnection con = new SqlConnection(Common.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Select ClassCode ID, ClassName DispText from ClassMaster where ActiveStatus=1 ", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }
            return ds;
        }
        #endregion
    }
}