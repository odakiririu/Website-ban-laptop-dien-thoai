namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }

        [StringLength(500)]
        public string UserName { get; set; }

        [StringLength(500)]
        public string Password { get; set; }

        [StringLength(500)]
        public string FullName { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(500)]
        public string Phone { get; set; }

        [StringLength(500)]
        public string Email { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(500)]
        public string CeateBy { get; set; }

        public DateTime? ModifielDate { get; set; }

        [StringLength(500)]
        public string ModifieldBy { get; set; }

        public bool Status { get; set; }
    }
}
