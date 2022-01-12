namespace coffeeshop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USER")]
    public partial class USER
    {
        [Column(TypeName = "numeric")]
        public decimal ID { get; set; }

        [Required]
        [StringLength(50)]
        public string NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string PASSWORD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? STATUS { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CREATE_DATE { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UPDATE_DATE { get; set; }
    }
}
