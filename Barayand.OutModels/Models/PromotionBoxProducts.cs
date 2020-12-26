using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barayand.OutModels.Models
{
    public class PromotionBoxProducts
    {
        public int X_Id { get; set; }
        public int X_SectionId { get; set; } = 0;
        public int X_ProdId { get; set; } = 0;
        public int X_ColorId { get; set; } = 0;
        public int X_WarrantyId { get; set; } = 0;
        public decimal X_DiscountedPrice { get; set; } = 0;
    }
}
