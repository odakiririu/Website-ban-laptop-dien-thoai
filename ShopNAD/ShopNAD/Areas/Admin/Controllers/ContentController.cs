using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNAD.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index()
        {
            var dao = new ContentDAO();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {  
            SetViewBag();
            return View();
        }
        /// <summary>
        /// truyền vào content
        /// </summary>
        /// <param name="content"></param>
        /// <returns>trả về kết quả đúng thì về trang index sai thì báo lỗi </returns>
        [HttpPost]
        public ActionResult Create(Content content)
        {
            if(ModelState.IsValid)
            {
                var dao = new ContentDAO();
                var result = dao.Insert(content);
                if(result == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("","Thêm bài viết không thành công");
                }    
            }    
            return View();
        }
        /// <summary>
        /// truyền vào biến selectedId mặc định bằng rỗng
        /// </summary>
        /// <param name="selectedId">lấy ra danh sách giá trị lấy là IDContentCategory, giá trị hiện về là Name</param>
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new CategoryContentDAO();
             ViewBag.IDContentCategory = new SelectList(dao.ListAll(), "IDContentCategory", "Name", selectedId);
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new ContentDAO();
            var content = dao.GetById(id);
            SetViewBag(content.IDContentCategory);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Content content)
        {
 
                var dao = new ContentDAO();
                var result = dao.Edit(content);
                if(result == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Chỉnh sửa bản ghi thất bại");
                }   
            SetViewBag(content.IDContentCategory);
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new ContentDAO().Delete(id);
            return RedirectToAction("Index", "Content");
        }
    }
}