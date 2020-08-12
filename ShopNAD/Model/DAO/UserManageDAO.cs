using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class UserManageDAO
    {
        private DbContextShopNAD db = null;
        public UserManageDAO()
        {
            db = new DbContextShopNAD();
        }
        public IEnumerable<User> ListAll(string keySearch, int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if(!string.IsNullOrEmpty(keySearch))
            {
                model = model.Where(x => x.UserName.Contains(keySearch) || x.FullName.Contains(keySearch));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page,pageSize);
        }
        public IEnumerable<User> GetUserByName(string keySearch, int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(keySearch))
            {
                model = model.Where(x => x.UserName.Contains(keySearch) || x.FullName.Contains(keySearch));
            }
            return model.OrderBy(x => x.UserName).ToPagedList(page, pageSize);
        }
        public bool ChangeStatus(long id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return (bool)user.Status;
        }
        public bool DeleteUser(long id)
        {

            var user = db.Users.Find(id);
            var result = db.Users.Remove(user);
            db.SaveChanges();
            return true;
        }
    }
}
