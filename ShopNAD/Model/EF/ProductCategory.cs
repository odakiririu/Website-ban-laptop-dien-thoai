namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductCategory")]
    public partial class ProductCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public long IDProductCategory { get; set; }

        [Required]
        [StringLength(500)]
        public string NameProductCategory { get; set; }

        public long? ParentID { get; set; }

        public long? DisplayOrder { get; set; }

        [StringLength(500)]
        public string SeoTittle { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(500)]
        public string CeateBy { get; set; }

        public DateTime? ModifielDate { get; set; }

        [StringLength(500)]
        public string ModifieldBy { get; set; }

        [StringLength(500)]
        public string MetaKeyword { get; set; }

        [StringLength(500)]
        public string MetaDescreption { get; set; }

        public bool? Status { get; set; }

        public bool? ShowOnHome { get; set; }

        [StringLength(500)]
        public string MetaTitle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
