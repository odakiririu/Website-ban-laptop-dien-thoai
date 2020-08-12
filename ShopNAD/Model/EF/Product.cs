namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        
        public long IDProduct { get; set; }

        [Display(Name = "Đề mục")]
        public long IDProductCategory { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Mã sản phẩm")]
        public string Code { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Tên sản phẩm")]
        public string NameProduct { get; set; }

        [StringLength(250)]
        [Display(Name = "Tiêu đề link")]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        [Display(Name = "Mô tả")]
        public string Desciption { get; set; }

        [StringLength(250)]
        [Display(Name = "Ảnh")]
        public string Images { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }
        [Display(Name = "Giá")]
        public decimal Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        [Display(Name = "Số lượng")]
        public int? Quantity { get; set; }

        [Display(Name = "Chi tiết")]
        public string Detail { get; set; }

        [Display(Name = "Bảo hành")]
        public int? Warranty { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreateDate { get; set; }

        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(250)]
        public string ModdifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        [Display(Name = "Mô tả chi tiết")]
        public string MetaDescriptions { get; set; }

        [Display(Name = "Trạng thái")]
        public bool? Status { get; set; }

        [Display(Name = "Hiện lên trang chủ")]
        public DateTime? TopHot { get; set; }

        [Display(Name = "Số lượt View")]
        public int? ViewCount { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}
