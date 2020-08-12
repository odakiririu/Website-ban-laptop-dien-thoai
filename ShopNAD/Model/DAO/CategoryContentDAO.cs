using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class CategoryContentDAO
    {
        private DbContextShopNAD db = null;
        public CategoryContentDAO()
        {
            db = new DbContextShopNAD();
        }
        public List<ContentCategory> ListAll()
        {
            return db.ContentCategories.Where(x => x.Status == true).ToList();
        }
    }
}
