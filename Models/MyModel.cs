using Dou.Misc.Attr;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace DouImp.Models
{
    public class eqEquip
    {
        [Key]
        [MaxLength(15)]
        [ColumnDef(Display = "資產編號", Index =0, Filter = true, DefaultValue = "", Sortable = true)]
        public string EQNO { set; get; }

        [MaxLength(50)]
        [ColumnDef(Display = "資產名稱",Index =1, DefaultValue = "")]
        public string EQNAME { set; get; }

        //[ColumnDef(Display = "主分類", Index =2, EditType = EditType.Select, SelectItems = "{'筆電':'筆電','桌機':'桌機','主機':'主機','軟體':'軟體','硬體':'硬體'}", Required = true)]
        [ColumnDef(Display = "主類別", Index = 2, Filter = true, EditType = EditType.Select, Required = true, DefaultValue = "",
        SelectSourceDbContextNamespace = "DouImp.Models.DouModelContextExt, DouImp", SelectSourceModelNamespace = "DouImp.Models.eqTypeA, DouImp",
        SelectSourceModelValueField = "TA01", SelectSourceModelDisplayField = "TA02")]
        public string EQTYPE1 { set; get; }

        //[ColumnDef(Display = "次分類", Index = 3, EditType = EditType.Select, SelectItems = "{'14吋筆電':'14吋筆電','15吋筆電':'15吋筆電','17吋筆電':'17吋筆電','桌子':'桌子','椅子':'椅子'}", Required = true)]
        [ColumnDef(Display = "次分類", Index = 3, Required = true, EditType = EditType.Select, SelectItemsClassNamespace = "DouImp.Models.TypeBSelectItems, DouImp")]
        //[ColumnDef(Display = "次類別", Index = 3, Required = true, EditType = EditType.Select, DefaultValue = "",
        //    SelectSourceDbContextNamespace = "DouImp.Models.DouModelContextExt, DouImp", SelectSourceModelNamespace = "DouImp.Models.eqTypeB, DouImp",
        //    SelectSourceModelValueField = "TB02", SelectSourceModelDisplayField = "TB03")]
        public string EQTYPE2 { set; get; }

        [ColumnDef(Display = "購置日期", Index =4, Filter = true, FilterAssign =FilterAssignType.Between, EditType = EditType.Date, Sortable = true)]
        public DateTime BUYDATE { set; get; }

        //[ColumnDef(Display = "部門", Index =5, EditType = EditType.Select, SelectItems = "{'永續中心':'永續中心','綠色中心':'綠色中心','環資中心':'環資中心','低碳組':'低碳組','講訓組':'講訓組','總經理室':'總經理室','人力資源室':'人力資源室','財務室':'財務室','總務室':'總務室','法務室':'法務室','資訊室':'資訊室'}", Required = true)]
        //↓用conn參考cmmDep
        [ColumnDef(Display = "部門", Index = 5, Filter = true, Required = true, EditType = EditType.Select, SelectItemsClassNamespace = "DouImp.Models.DepSelectItems, DouImp")]
        //↓用員工部門元件
        //[ColumnDef(Display = "部門", Index = 5, Filter=true, Required = true, EditType = EditType.Select, SelectItemsClassNamespace = "DouImp.Models.mmDepartmentSelectItemsClassImpForConsultRecord, DouImp")]
        public string DCODE { set; get; }

        //[MaxLength(10)]
        //[ColumnDef(Display = "保管人職號", Index =6, Required = false, Visible = false, VisibleEdit = false, DefaultValue = "")]
        //↓用conn參考cmmEmp
        //[ColumnDef(Display = "保管人", Index = 6, Required = true, EditType = EditType.Select, SelectItemsClassNamespace = "DouImp.Models.MnoSelectItems, DouImp")]
        //↓用員工部門元件
        [ColumnDef(Display = "保管人", Index = 6, Required = true, EditType = EditType.Select, SelectItemsClassNamespace = "DouImp.Models.EmployeeSelectItemsClassImpForConsultRecord, DouImp")]
        public string MNO { set; get; }

        //[MaxLength(10)]
        //[ColumnDef(Display = "保管人姓名", Index =7, Required = true, DefaultValue = "")]
        //public string NAME { set; get; }

        [MaxLength(30)]
        //[ColumnDef(Display = "地點", Index = 8, EditType = EditType.Select, SelectItems = "{'會本部一樓':'會本部一樓','會本部二樓':'會本部二樓','環保署':'環保署','基管會':'基管會','能源局':'能源局','工業局':'工業局','台北市政府':'台北市政府','新北市政府':'新北市政府','桃園市政府':'桃園市政府','台南市政府':'台南市政府','宜蘭縣政府':'宜蘭縣政府'}", Required = true, DefaultValue = "")]
        [ColumnDef(Display = "地點", Index = 8, EditType = EditType.Select , Required = true, DefaultValue = "", 
            SelectSourceDbContextNamespace = "DouImp.Models.DouModelContextExt, DouImp",
            SelectSourceModelNamespace = "DouImp.Models.eqPlace, DouImp", 
            SelectSourceModelValueField ="PE01", 
            SelectSourceModelDisplayField ="PE02")]
        public string PLACE { set; get; }

        [MaxLength(500)]
        [ColumnDef(Display = "規格敘述", Index =9, Required = true, DefaultValue = "")]
        public string EQMEMO { set; get; }

        [ColumnDef(Display = "購置金額", Index = 10, Required = true, Visible =false)]
        public double EQMONEY { set; get; }

        [MaxLength(30)]
        [ColumnDef(Display = "是否故障", Index =11, Visible = false, EditType = EditType.Radio, SelectItems = "{'待檢測':'待檢測','送修中':'送修中','故障':'故障'}")]
        public string FAULT { set; get; }

        [MaxLength(500)]
        [ColumnDef(Display = "故障說明", Index = 12, Visible = false)]
        public string FAULTMEMO { set; get; }

        [ColumnDef(Display = "是否報廢", Index =13, Visible = false, EditType = EditType.Radio, SelectItems = "{'false':'未報廢','true':'已報廢'}", Required = true, DefaultValue = "false")]
        public bool SCR { set; get; }

        [ColumnDef(Display = "報廢日期", Index =14, Visible = false, EditType = EditType.Date)]
        public DateTime? SCRDATE { set; get; }

        [MaxLength(500)]
        [ColumnDef(Display = "備註1", Index = 15)]
        public string MEMO1 { set; get; }

        [MaxLength(500)]
        [ColumnDef(Display = "備註2", Index = 16)]
        public string MEMO2 { set; get; }

        //↓用conn參考cmmEmp
        [ColumnDef(Display = "異動人", Index = 31, Required = true, VisibleEdit =false, Visible = true, EditType = EditType.Select, SelectItemsClassNamespace = "DouImp.Models.MnoSelectItems, DouImp")]
        public string EDTPSN { set; get; }
        //測試可以看不能修改，但後台要自動更新
        //public string EDTPSN { private set; get; }
        //        public void setEDTPSN(String EPTPSN) {
        //            this.EDTPSN = EPTPSN;
        //        }

        [ColumnDef(Display = "異動時間", Index =32, VisibleEdit = false, Visible = true, EditType = EditType.Datetime)]
        public DateTime EDTTIME { set; get; }
        //測試~可以看不能修改，但後台要自動更新
        //public DateTime EDTTIME { private set; get; }
        //        public void setEDTTIME(DateTime EDTTIME)
        //        {
        //            this.EDTTIME = EDTTIME;
        //        }


        [ColumnDef(Display = "盤點日期", Index =19, Visible = false, EditType = EditType.Date)]
        public DateTime? IVTDATE { set; get; }

        [ColumnDef(Display = "盤點狀態", Index =20, Visible = false, EditType = EditType.Radio, SelectItems = "{'false':'未盤點','true':'已盤點'}")]
        public bool IVTCK { set; get; }

        [MaxLength(30)]
        [ColumnDef(Display = "採請購單編號", Index = 21, Visible = false)]
        public string ORDERNO { set; get; }

        [MaxLength(20)]
        [ColumnDef(Display = "作業系統", Index = 22)]
        public string OS { set; get; }

        [MaxLength(20)]
        [ColumnDef(Display = "Office版本", Index = 23)]
        public string OFFICE { set; get; }

        [MaxLength(20)]
        [ColumnDef(Display = "Office代碼", Index = 24, Visible = false)]
        public string OFCNO { set; get; }

        [MaxLength(50)]
        [ColumnDef(Display = "供應商", Index = 25, Visible = false)]
        public string SPR { set; get; }

        [ColumnDef(Display = "保固期限", Index = 26, Required = true, Visible = false)]
        public int WRTYR { set; get; }

        [ColumnDef(Display = "耐用年限", Index = 27, Required = true, Visible = false)]
        public int DURYR { set; get; }
    }




    [Table("cmmEmp")]
    public class cmmEmp
    {//員工代碼表

        [Key]
        [ColumnDef(Index = 0)]
        public string Mno { set; get; }
        public string Name { set; get; }
        public bool Quit { set; get; }
    }


    [Table("cmmDep")]
    public class cmmDep
    {//部門代碼表

        [Key]
        [ColumnDef(Index =0)]
        public string DCode { set; get; }
        public string DName { set; get; }
        public string DCkNo1 { set; get; }
        public string DCkName1 { set; get; }
        public string DCkNo2 { set; get; }
        public string DCkName2 { set; get; }
        public string DCkNo3 { set; get; }
        public string DCkName3 { set; get; }
        public string DAdmino { set; get; }
        public string Dnickname { set; get; }
        public string Duse { set; get; }
        public string DCkNo { set; get; }
        public string DCkName { set; get; }

    }


    public class TypeBSelectItems : Dou.Misc.Attr.SelectItemsClass
    {
        public override IEnumerable<KeyValuePair<string, object>> GetSelectItems()
        {
            //return new Dou.Models.DB.ModelEntity<eqTypeB>(new DouImp.Models.DouModelContextExt()).GetAll().ToArray()
            
            return new DouImp.Models.DouModelContextExt().Database.SqlQuery<eqTypeB>("select * from eqTypeB order by TB01,TB02").ToArray()
            //new DouModelContextExt().Database.SqlQuery<EqmModule>("select.....").ToList();//.ToArray();
            .Select(
                s => new KeyValuePair<string, object>(s.TB02, s.TB03)
                );
        }
    }


    //測試cmmDep(SQL) → 回傳MyController
    //public class DepQQ
    //{

        //public DepQQ(string aa)
        //{ string bb;
        //  return bb=DouImp.Models.FtisModelContext().Database.SqlQuery<cmmDep>("SELECT * FROM cmmDep where '" + aa + "' Duse='Y' order by DCode").ToArray();
        //}

    //}
    


    //測試cmmDep(SQL)
    public class DepSelectItems : Dou.Misc.Attr.SelectItemsClass
    {
        public override IEnumerable<KeyValuePair<string, object>> GetSelectItems()
        {

            return new DouImp.Models.FtisModelContext().Database.SqlQuery<cmmDep>("SELECT * FROM cmmDep where Duse='Y' order by DCode").ToArray()
            .Select(
                s => new KeyValuePair<string, object>(s.DCode, s.Dnickname+ s.DCode)
                );
        }
    }


    //測試cmmEmp(SQL)
    public class MnoSelectItems : Dou.Misc.Attr.SelectItemsClass
    {
        public override IEnumerable<KeyValuePair<string, object>> GetSelectItems()
        {

            //return new DouImp.Models.FtisModelContext().Database.SqlQuery<cmmEmp>("SELECT * FROM cmmEmp where quit=0 and mno>='10000' and mno<>'19999' and mno<>'99999' order by mno").ToArray()
            return new DouImp.Models.FtisModelContext().Database.SqlQuery<cmmEmp>("SELECT * FROM cmmEmp where quit=0 and mno<>'19999' and mno<>'99999' order by mno").ToArray()
            .Select(
                s => new KeyValuePair<string, object>(s.Mno, s.Mno + s.Name)
                );
            //return new DouImp.Models.FtisModelContext().Database.SqlQuery<cmmEmp>("SELECT * FROM cmmEmp where quit=0 and mno<'10000' and mno<>'19999' and mno<>'99999' order by mno").ToArray()
            //.Select(
            //    s => new KeyValuePair<string, object>(s.Mno, s.Mno + s.Name)
            //    );
        }
    }


    //引用清哥~參考FtisHelper.dll(Department部門)
    public class mmDepartmentSelectItemsClassImpForConsultRecord : SelectItemsClass
    {
        public const string AssemblyQualifiedName = "DouImp.Models.mmDepartmentSelectItemsClassImpForConsultRecord, DouImp";

        protected static IEnumerable<FtisHelper.DB.Model.Department> _mmdeps;
        protected static IEnumerable<FtisHelper.DB.Model.Department> mmDEPS
        {
            get
            {
                if (_mmdeps == null)
                {
                    using (var fdb = FtisHelper.DB.FtisModelContext.Create())
                    {
                        _mmdeps = fdb.Department.Where(s => s.DUse == "Y").OrderBy(s => s.DCode).ToArray();
                        //_deps = fdb.Employee.Where(k => k.Quit=false).ToArray()

                        //using (var db = new DouImp.Models.DouModelContextExt())
                        //{
                        //    string[] exclude = new string[] { "01", "14", "15", "16", "17", "30", "22", "99" };
                        //    var cdeps = db.User.Where(s => s.dep != null).Select(s => s.dep).Distinct().ToArray().Where(s => !exclude.Contains(s));
                        //
                        //    _deps = _deps.Where(s => cdeps.Contains(s.DCode));
                        //}
                    }
                }
                return _mmdeps;
            }
        }
        public override IEnumerable<KeyValuePair<string, object>> GetSelectItems()
        {
            return mmDEPS.Select(s => new KeyValuePair<string, object>(s.DCode, s.DName+ s.DCode));
        }
    }


    //引用清哥~參考FtisHelper.dll(員工Employee)
    public class EmployeeSelectItemsClassImpForConsultRecord : SelectItemsClass
    {
        public const string AssemblyQualifiedName = "DouImp.Models.EmployeeSelectItemsClassImpForConsultRecord, DouImp";

        protected static IEnumerable<FtisHelper.DB.Model.Employee> _mno;
        protected static IEnumerable<FtisHelper.DB.Model.Employee> MNOS
        {
            get
            {
                if (_mno == null)
                {
                    using (var fdb = FtisHelper.DB.FtisModelContext.Create())
                    {
                        //;_mno = fdb.Employee.Where(k => k.Quit == false).OrderBy(k => k.Mno).ToArray();
                        _mno = fdb.Employee.Where(k => (k.Quit == false) && (k.Mno != "99999") && (k.Mno != "19999")).OrderBy(k => k.Mno).ToArray();
                    }
                }
                return _mno;
            }
        }
        public override IEnumerable<KeyValuePair<string, object>> GetSelectItems()
        {
            return MNOS.Select(s => new KeyValuePair<string, object>(s.Mno, s.Mno+s.Name));
        }
    }


}