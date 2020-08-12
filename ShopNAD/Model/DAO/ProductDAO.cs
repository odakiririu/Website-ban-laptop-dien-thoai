using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ProductDAO
    {
        DbContextShopNAD db = null;
         
        public ProductDAO()
        {
            db = new DbContextShopNAD();
        }
        /// <summary>
        /// lấy ra danh sach những sp mới đc sắp xếp thep ngày
        /// </summary>
        /// <param name="top">tham số truyền vào 4</param>
        /// <returns></returns>
        public List<Product> ListNewProduct (int top)
        {
            return db.Products.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }

        public List<Product> ListHotProduct(int top)
        {
            return db.Products.Where(x=>x.TopHot !=null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }

        public Product ProductDetail (long ProId)
        {
            return db.Products.Find(ProId);
        }

        public List<Product> RelatedProduct (long ProId)
        {
            var product = db.Products.Find(ProId);
            return db.Products.Where(x => x.IDProduct != ProId && x.IDProductCategory == product.IDProductCategory).OrderBy(x=>x.CreateDate).ToList();
        }

        public List<Product> GetListAllProductByID(long ProId)
        {
            
            var model=  db.Products.Where(x => x.IDProductCategory == ProId).OrderByDescending(x=>x.CreateDate).ToList();
            return model;
        }
    }
}
