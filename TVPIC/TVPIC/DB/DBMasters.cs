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
        public DataTable FillSubjectData(string ClassCode, int CategoryID)
        {
            var ds = new DataTable();
            using (SqlConnection con = new SqlConnection(Common.connectionString))
            {
                var sql = "Select ID, ('['+SubjectCode + '] ' + Subject) as DispText  from SubjectMaster ";
                sql += " where ActiveStatus=1  and ClassCode=@ClassCode and CategoryID=@categoryID order by SubjectCode";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ClassCode", ClassCode);
                    cmd.Parameters.AddWithValue("@categoryID", CategoryID);
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
        public DataTable FillClassData()
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
        #region ClassCategory
        public DataTable FillClassCategory(string ClassCode)
        {
            var ds = new DataTable();
            using (SqlConnection con = new SqlConnection(Common.connectionString))
            {
                var sql = "Select ID, ('['+CategoryCode + '] ' + Category) as DispText  from ClassCategoryMaster ";
                sql += " where ActiveStatus=1  and ClassCode=@ClassCode order by CategoryCode ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ClassCode", ClassCode);
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