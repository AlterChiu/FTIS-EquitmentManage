using Dou.Misc.Attr;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace DouImp.Models
{
    [Table ("eqTypeA")]
    public class eqTypeA
    {
        [Key]
        [MaxLength(5)]
        [ColumnDef(Display = "主分類編號", DefaultValue = "", Required = true, Sortable = true)]
        public string TA01 { set; get; }

        [MaxLength(50)]
        [ColumnDef(Display = "主分類", Index = 1, DefaultValue = "", Required = true)]
        public string TA02 { set; get; }
    }
}
