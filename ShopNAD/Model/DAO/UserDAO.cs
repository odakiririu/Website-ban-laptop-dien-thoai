using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class UserDAO
    {
        DbContextShopNAD db = null;

        public UserDAO()
        {
            db = new DbContextShopNAD();
        }

        public bool CheckUserName(string userName)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);
            if(result != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// sử dụng để đăng kí thành viên
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public long InsertAcc (User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return 1;
        }

        public long InsertForFB(User user)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == user.UserName);
            if(result == null)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return user.ID;
            }
            else
            {
                return user.ID;
            }
        }

        public int LoginUser(string userName, string password)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName && x.Password == password);
            if(result != null)
            {
                if(result.Status == false)
                {
                    return 2;
                }
                return 1;
            }
            return 0;
        }
    }
}
