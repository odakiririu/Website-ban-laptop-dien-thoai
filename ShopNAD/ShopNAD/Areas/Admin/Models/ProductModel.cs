using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopNAD.Areas.Admin.Models
{
    public class ProductModel
    {
        [Key]
        public long IDProduct { get; set; }

        public long IDProductCategory { get; set; }


        public string Code { get; set; }


        public string NameProduct { get; set; }

       
        public string MetaTitle { get; set; }

        
        public string Desciption { get; set; }

        public string Images { get; set; }

        public HttpPostedFileBase FileImage { get; set; }

        public string MoreImages { get; set; }

        public decimal Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public int? Quantity { get; set; }

        public string Detail { get; set; }

        public int? Warranty { get; set; }

        public DateTime? CreateDate { get; set; }

        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModdifiedBy { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescriptions { get; set; }

        public bool? Status { get; set; }

        public DateTime? TopHot { get; set; }

        public int? ViewCount { get; set; }
    }
}