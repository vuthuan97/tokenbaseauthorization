using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIAuth
{
    public class UserRepository : IDisposable
    {
        apiEntities DB = new apiEntities();
        public UserWeb ValidateUser(string user,string pass)
        {
            return DB.UserWeb.FirstOrDefault(u => u.userName==user && u.password == pass);
        }
        public void Dispose()
        {
            DB.Dispose();
        }
    }
}