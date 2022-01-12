namespace coffeeshop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USER_ROLE
    {
        [Column(TypeName = "numeric")]
        public decimal ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? USER_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ROLE_ID { get; set; }
    }
}
