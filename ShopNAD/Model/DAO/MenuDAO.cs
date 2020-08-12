using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class MenuDAO
    {
        DbContextShopNAD db = null;
        public MenuDAO()
        {
            db = new DbContextShopNAD();
        }
        public List<Menu> GetListID(long id)
        {
            return db.Menus.Where(x => x.IDMenuType == id && x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}
