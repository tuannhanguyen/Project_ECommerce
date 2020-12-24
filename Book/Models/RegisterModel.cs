using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Book.Models
{
    public class RegisterModel
    {
        private dbbookEntities context = null;
        Cyptop cyptop = new Cyptop();
        public RegisterModel()
        {
            context = new dbbookEntities();
        }
        public bool Register(string name, string phone, string email, string username, string password)
        {
            string pwd = Cyptop.Encrypt(password, true);

            SqlParameter[] sqlParams =
            {
                new SqlParameter("@Name", System.Data.SqlDbType.NVarChar),
                new SqlParameter("@PhoneNumber", System.Data.SqlDbType.NVarChar),
                new SqlParameter("@Email", System.Data.SqlDbType.NVarChar),
                new SqlParameter("@username", System.Data.SqlDbType.NVarChar),
                new SqlParameter("@password", System.Data.SqlDbType.NVarChar)
            };

            sqlParams[0].Value = name;
            sqlParams[1].Value = phone;
            sqlParams[2].Value = email;
            sqlParams[3].Value = username;
            sqlParams[4].Value = pwd;

            var res = context.Database.SqlQuery<bool>("sp_Account_Register @Name, @PhoneNumber, @Email, @username, @password", sqlParams).SingleOrDefault();

            return res;
        }
    }
}