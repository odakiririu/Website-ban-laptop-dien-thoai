using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using PagedList.Mvc;

namespace Model.DAO
{
    public class AdminManageDAO
    {
        private DbContextShopNAD db = null;
        public AdminManageDAO()
        {
            db = new DbContextShopNAD();
        }
        public List<AccAdmin> GetListAdmin()
        {
            return db.AccAdmins.ToList();
        }
        public IEnumerable<AccAdmin> GetAccAdminByName(string keySearch, int page, int pageSize)
        {
            IQueryable<AccAdmin> model = db.AccAdmins;
            if (!string.IsNullOrEmpty(keySearch))
            {
                model = model.Where(x => x.UserName.Contains(keySearch) ||x.FullName.Contains(keySearch));
            }
            return model.OrderBy(x => x.UserName).ToPagedList(page, pageSize);
        }
        //Create acc admin
        public string CreateAdmin(AccAdmin entityAdmin)
        {
            db.AccAdmins.Add(entityAdmin);
            db.SaveChanges();
            return entityAdmin.UserName;
        }
        //kiểm tra tên tài khoản quản trị khi tạo mới có trùng hay k 
        public bool FindUser(string userName)
        {
            var result = db.AccAdmins.SingleOrDefault(x => x.UserName == userName);
            if (result != null)
            {
                return true;
            }
            return false;
        }
        //Edit tài khoản quản trị
        public bool Edit(AccAdmin entity)
        {
            var user = db.AccAdmins.Find(entity.ID);
            user.FullName = entity.FullName;   
            user.Phone = entity.Phone;
            user.Address = entity.Address;
            user.Email = entity.Email;
            db.SaveChanges();
            return true;

        }
        public AccAdmin ViewDetail(int id)
        {
            var result = db.AccAdmins.Find(id);
            return result;
        }

        public bool Delete(int id)
        {
            var user = db.AccAdmins.Find(id);
            db.AccAdmins.Remove(user);
            db.SaveChanges();
            return true;
        }
    }
}
