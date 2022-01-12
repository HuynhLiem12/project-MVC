using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace coffeeshop.Models
{
    public  partial class ProductMasterData
    {   
        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }

    }
}