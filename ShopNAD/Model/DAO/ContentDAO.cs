using Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Model.DAO
{
    public class ContentDAO
    {
        DbContextShopNAD db = null;
        public ContentDAO()
        {
            db = new DbContextShopNAD();

        }
        public List<Content> ListAll()
        {
            return db.Contents.ToList();
        }
        public bool Insert(Content content)
        {
            db.Contents.Add(content);
            db.SaveChanges();
            return true;
        }
        /// <summary>
        /// truyền vào biến id
        /// </summary>
        /// <param name="id">trả về id của contetn đang sửa</param>
        /// <returns></returns>
        public Content GetById(long id)
        {
            return db.Contents.Find(id);
        }
        /// <summary>
        /// đây là hàm edit nhưng chưa làm đc :v
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public bool Edit(Content content)
        {
            return true;
        }
        /// <summary>
        /// hàm xóa
        /// </summary>
        /// <param name="id">tìm id của bản ghi</param>
        /// <returns>true</returns>
        public bool Delete(long id)
        {
            var content = db.Contents.Find(id);
            db.Contents.Remove(content);
            db.SaveChanges();
            return true;
        }
    }
}
