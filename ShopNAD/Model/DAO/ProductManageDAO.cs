using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Model.DAO
{
    public class ProductManageDAO
    {
        DbContextShopNAD db = null;

        public ProductManageDAO()
        {
            db = new DbContextShopNAD();
        }

        public IEnumerable<Product> GetListAll(string keySearch, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(keySearch))
            {
                model = model.Where(x => x.NameProduct.Contains(keySearch));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        public List<ProductCategory> GetListCategory ()
        {
            var result = db.ProductCategories.ToList();
            return result;
        }
        public bool Insert(Product product)
        {
            var result = db.Products.Add(product);
            db.SaveChanges();
            return true;
        }
        public Product FindByIdCategory(long Id)
        {
            return db.Products.Find(Id);
        }
        public bool Edit(Product entity)
        {
            var result = db.Products.Find(entity.IDProduct);
            result.NameProduct = entity.NameProduct;
            result.Code = entity.Code;
            result.MetaTitle = entity.MetaTitle;
            result.MetaDescriptions = entity.MetaDescriptions;
            result.Price = entity.Price;
            result.Warranty = entity.Warranty;
            result.Quantity = entity.Quantity;
            result.Detail = entity.Detail;
            result.Status = entity.Status;
            result.Images = entity.Images;
            db.SaveChanges();
            return true;
        }

        public bool Delete(long Id)
        {
            var product = db.Products.Find(Id);
            db.Products.Remove(product);
            db.SaveChanges();
            return true;
        }
    }
}
