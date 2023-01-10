using Dou.Misc.Attr;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace DouImp.Models
{
    public class eqPlace
    {
        [Key]
        [MaxLength(5)]
        [ColumnDef(Display = "地點編號", Index = 0, DefaultValue = "", Required = true, Sortable= true)]
        public string PE01 { set; get; }

        [MaxLength(50)]
        [ColumnDef(Display = "地點", Index = 1, DefaultValue = "", Required = true)]
        public string PE02 { set; get; }
    }
}
