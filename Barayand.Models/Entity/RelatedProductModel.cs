using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Barayand.Models.Extra;
namespace Barayand.Models.Entity
{
    public class RelatedProductModel :BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PR_Id {get; set;}

        public int PR_PId { get; set; }
        public int PR_RId { get; set; }
    }
}