using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopNAD.Areas.Admin.Models
{
    public class ProductCategoryModel
    {
        [Key]
        public long IDProductCategory { get; set; }

        public string NameProductCategory { get; set; }

        public long? ParentID { get; set; }

        public long? DisplayOrder { get; set; }

      
        public string SeoTittle { get; set; }

        public DateTime? CreateDate { get; set; }


        public string CeateBy { get; set; }

        public DateTime? ModifielDate { get; set; }


        public string ModifieldBy { get; set; }


        public string MetaKeyword { get; set; }


        public string MetaDescreption { get; set; }

        public bool? Status { get; set; }

        public bool? ShowOnHome { get; set; }


        public string MetaTitle { get; set; }
    }
}