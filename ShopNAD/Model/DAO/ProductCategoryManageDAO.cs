using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ProductCategoryManageDAO
    {
        DbContextShopNAD db = null;

        public ProductCategoryManageDAO()
        {
            db = new DbContextShopNAD();
        }

        public List<ProductCategory> GetListAll()
        {
            return db.ProductCategories.ToList();
        }
        ///thêm 1 đề mục
        public bool Insert(ProductCategory cate)
        {
            var result = db.ProductCategories.Add(cate);
            db.SaveChanges();
            return true;

        }
        //xóa
        public bool Delete(long id)
        {
            var cate = db.ProductCategories.Find(id);
            var result = db.ProductCategories.Remove(cate);
            db.SaveChanges();
            return true;    
        }

        public ProductCategory ViewEdit(long Id)
        {
            return db.ProductCategories.Find(Id);
        }
        public bool Edit(ProductCategory entity)
        {
            var cate = db.ProductCategories.Find(entity.IDProductCategory);
            cate.NameProductCategory = entity.NameProductCategory;
            cate.DisplayOrder = entity.DisplayOrder;
            cate.Status = entity.Status;
            cate.MetaTitle = entity.MetaTitle;
            db.SaveChanges();
            return true;
        }
    }
}
