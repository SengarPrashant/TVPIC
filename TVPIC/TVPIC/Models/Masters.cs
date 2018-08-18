using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TVPIC.DB;
using TVPIC.Models;

namespace TVPIC.Models
{
    public class Masters
    {
        public DataTable FillClass()
        {
            DBMasters db = new DBMasters();
            return db.FillClassData();
        }
        public DataTable FillSubject(string ClassCode, int CategoryID)
        {
            DBMasters db = new DBMasters();
            return db.FillSubjectData(ClassCode, CategoryID);
        }
        public DataTable FillClassCategory(string ClassCode)
        {
            DBMasters db = new DBMasters();
            return db.FillClassCategory(ClassCode);
        }
    }
}