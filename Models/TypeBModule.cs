using Dou.Misc.Attr;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace DouImp.Models
{
    [Table("eqTypeB")]
    public class eqTypeB
    {
        [Key]
        [Column(Order = 1)]
        [MaxLength(5)]
        [ColumnDef(Display = "主分類編號",IsPrimaryKey=true, DefaultValue = "", Required = true, Sortable = true)]
        public string TB01 { set; get; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(5)]
        [ColumnDef(Display = "次分類編號", IsPrimaryKey =true, Index = 1, DefaultValue = "", Required = true, Sortable = true)]
        public string TB02 { set; get; }

        [MaxLength(50)]
        [ColumnDef(Display = "次分類", Index = 2, DefaultValue = "", Required = true)]
        public string TB03 { set; get; }
    }
}
