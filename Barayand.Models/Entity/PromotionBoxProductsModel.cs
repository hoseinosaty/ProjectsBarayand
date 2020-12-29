﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Barayand.Models.Extra;

namespace Barayand.Models.Entity
{
    public class PromotionBoxProductsModel:BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int X_Id { get; set; }
        public int X_SectionId { get; set; } = 0;
        public int X_ProdId { get; set; } = 0;
        public int X_ColorId { get; set; } = 0;
        public int X_WarrantyId { get; set; } = 0;
        public decimal X_DiscountedPrice { get; set; } = 0;
        public DateTime X_StartDate { get; set; }//استفاده فقط در فروش ویژه
        public DateTime X_EndDate { get; set; }//استفاده فقط در فروش ویژه
        public bool X_Status { get; set; } = true;//استفاده فقط در فروش ویژه
        public bool X_ShowInIndex { get; set; } = false;//استفاده فقط در فروش ویژه

    }
}
