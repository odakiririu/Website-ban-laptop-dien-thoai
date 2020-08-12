using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopNAD.Areas.Admin.Models
{
    public class ContentModel
    {
        public long IDContent { get; set; }
        [Required(ErrorMessage = "Chưa nhập tên bài viết")]
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public string Desciption { get; set; }
        public string Images { get; set; }
        public long? IDContentCategory { get; set; }
        [Required(ErrorMessage = "Chưa nhập nội dung bài viết")]
        public string Detail { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescriptions { get; set; }
        public bool? Status { get; set; }
        public DateTime? TopHot { get; set; }
        public int? ViewCount { get; set; }
        public string Tags { get; set; }
    }
}