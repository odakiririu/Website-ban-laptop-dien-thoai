using Model.EF;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class AdminLoginDAO
    {
        private DbContextShopNAD db = null;
            public AdminLoginDAO()
        {
            db = new DbContextShopNAD();
        }
         public int LoginAdmin(string userName, string password)
        {
            var result = db.AccAdmins.SingleOrDefault(x => x.UserName == userName && x.Password == password);
            if(result== null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
