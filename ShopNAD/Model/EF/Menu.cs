namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        [Key]
        public long IDMenu { get; set; }

        [Required]
        [StringLength(500)]
        public string NameMenu { get; set; }

        [StringLength(500)]
        public string Link { get; set; }

        public int? DisplayOrder { get; set; }

        public bool? Status { get; set; }

        [StringLength(500)]
        public string Target { get; set; }

        public long IDMenuType { get; set; }

        public virtual MenuType MenuType { get; set; }
    }
}
