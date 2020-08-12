using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ProductCategoryDAO
    {
        DbContextShopNAD db = null;

        public ProductCategoryDAO() 
        {
            db = new DbContextShopNAD();
        }
        /// <summary>
        /// lấy ra danh sách thể loại và sắp sếp
        /// </summary>
        /// <returns></returns>
        public List<ProductCategory> GetListProductCategories()
        {
            return db.ProductCategories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
        public ProductCategory ViewDetail (long CateId)
        {
            return db.ProductCategories.Find(CateId);
        }
    }
}
