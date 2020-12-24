using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Book.Models
{
    public class LoginModel
    {
        private dbbookEntities context = null;
        Cyptop cyptop = new Cyptop();
        public LoginModel()
        {
            context = new dbbookEntities();
        }
        public int Login(string username, string password)
        {
            string pwd = Cyptop.Encrypt(password, true);
            SqlParameter[] sqlParams =
            {
                new SqlParameter("@username", System.Data.SqlDbType.NVarChar),
                new SqlParameter("@password", System.Data.SqlDbType.NVarChar)
            };

            sqlParams[0].Value = username;
            sqlParams[1].Value = pwd;

            var res = context.Database.SqlQuery<int>("sp_Account_Login @username, @password", sqlParams).SingleOrDefault();

            return res;
        }
    }
}