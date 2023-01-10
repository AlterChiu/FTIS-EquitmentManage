using Dou.Models.DB;
using DouImp.Controllers.Manager;
using DouImp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using OfficeOpenXml;
using System.Diagnostics;

namespace DouImp.Controllers
{
    [Dou.Misc.Attr.MenuDef(Id = "Controla", Name = "資產總表", Index =1 , MenuPath = "", Action = "Index", Func = Dou.Misc.Attr.FuncEnum.ALL, AllowAnonymous = false)]

    //分頁元件APaginationModelController vs 全顯元件AGenericModelController
    public class MyController : Dou.Controllers.APaginationModelController<eqEquip>
    //public class MyController : Dou.Controllers.AGenericModelController<eqEquip>
    {
        // GET: My
        public ActionResult Index()
        {
            return View();
        }

        //相機測試test1
        public ActionResult test1()
        {
            ViewBag.TestA = "AAA";
            ViewData["TestB"] = "BBB";
            TempData["TestC"] = "CCC";

            return View("test1");
        }


        //啟動相機
        public ActionResult ivt1()
        {
            //ViewBag.TestA = "AAA";
            //ViewData["TestB"] = "BBB";
            //TempData["TestC"] = "CCC";

            return View("ivt1");
        }



        //盤點
        [HttpPost]
        public ActionResult ivt2(string show_code)
        {
            //Debug.WriteLine("測試條碼1：" + show_code);
            //ViewBag.TestA = "【" + show_code + "】";

            //盤點程序
            var sqlvttxt1 = @"SELECT * FROM eqEquips where EQNO='" + show_code + "'";
            var rsa = new DouImp.Models.DouModelContextExt().Database.SqlQuery<eqEquip>(sqlvttxt1).ToList();
            string tmpaa = "";
            foreach (var rowa in rsa)
            {
                DateTime dt = DateTime.Now;

                var sqlvttxt2 = @"update eqEquips set IVTDATE='" + dt.ToShortDateString().ToString() + "',IVTCK=1 where EQNO='" + show_code + "'";
                //Debug.WriteLine(sqlvttxt2);
                var rsb = new DouImp.Models.DouModelContextExt().Database.ExecuteSqlCommand(sqlvttxt2);

                tmpaa = "y";
            }

            if (tmpaa == "y")
            {
                ViewBag.TestA = "【" + show_code + "】盤點ok!!";
            }
            else
            {
                ViewBag.TestA = "【" + show_code + "】查無資料!!";
            }
            rsa.Clear();


            return View("ivt1");
        }




        [HttpPost]
        public ActionResult rpt2(string searchString, string searchString2)
        {
            //Debug.WriteLine("測試訊息1：" + searchString);
            //Debug.WriteLine("測試訊息2：" + searchString2);

            var fileName1 = Server.MapPath("~/資產清單_v202210.xlsx");
            var fileName2 = Server.MapPath("~/") + "tmp/資產清單" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xlsx";

            FileInfo file1 = new FileInfo(fileName1);

            //確認報表範本檔案存在
            if (file1.Exists)
            {
                //存在，就複製一份
                file1.CopyTo(fileName2);


                // 關閉新許可模式通知
                //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                // 沒設置的話會跳出 Please set the excelpackage.licensecontext property


                //開execl檔
                //using (ExcelPackage package = new ExcelPackage(new FileInfo(@"d:\test.xlsx"))) { }

                FileInfo file2 = new FileInfo(@fileName2);

                //載入Excel檔案
                using (ExcelPackage ep = new ExcelPackage(file2))
                {
                    //指定excel哪一個頁籤
                    ExcelWorksheet sheet1 = ep.Workbook.Worksheets[1];


                    //輸出view的欄位
                    //sheet1.Cells["R1"].Value = "【" + searchString + "】";
                    //sheet1.Cells["S1"].Value = "【" + searchString2 + "】";


                    //var sqltxt1 = @"SELECT top 15 b.Name,a.* FROM eqEquips a left join ftis_mis.dbo.cmmEmp b on a.MNO=b.Mno order by a.BUYDATE desc";

                    var sqltxt1 = @"SELECT top 250 * FROM eqEquips order by SCRDATE desc,BUYDATE desc";
                    //var sqltxt1 = @"SELECT * FROM eqEquips order by SCRDATE desc,BUYDATE desc";

                    //var rs1 = new DouImp.Models.FtisModelContext().Database.SqlQuery<cmmEmp>(sqltxt1).ToArray();
                    var rs1 = new DouImp.Models.DouModelContextExt().Database.SqlQuery<eqEquip>(sqltxt1).ToList();

                    //var tmpaa = @ViewData.ModelState["EQNO"].Value;
                    //string tmpaa = @ViewData.form["EQNO"].Value;
                    //string tmpaa = "";

                    //rs1.Select(e => e.Mno + "_" + e.Quit.ToString()).ToList();
                    var ii = 4;
                    foreach (var rows in rs1)
                    {
                        sheet1.Cells["A" + ii].Value = rows.EQNO;
                        sheet1.Cells["B" + ii].Value = rows.ORDERNO;
                        sheet1.Cells["C" + ii].Value = rows.OFCNO;
                        sheet1.Cells["D" + ii].Value = rows.EQNAME;
                        sheet1.Cells["E" + ii].Value = rows.EQMEMO;
                        sheet1.Cells["H" + ii].Value = rows.EQMONEY;

                        if (rows.DCODE != "")
                        {
                            var sqltxt2 = @"SELECT * FROM cmmDep where dcode='" + rows.DCODE + "'";
                            //sheet1.Cells["E1"].Value = sqltxt2;

                            var rs2 = new DouImp.Models.FtisModelContext().Database.SqlQuery<cmmDep>(sqltxt2).ToArray();
                            foreach (var row2 in rs2)
                            { sheet1.Cells["I" + ii].Value = row2.Dnickname; }
                            //rs2.Clear();
                        }
                        else { sheet1.Cells["I" + ii].Value = rows.DCODE; }
                        //sheet1.Cells["I" + ii].Value = rows.DCODE;

                        if (rows.MNO!="")
                         {
                            var sqltxt2 = @"SELECT * FROM cmmEmp where mno='" + rows.MNO + "'";
                            //sheet1.Cells["F1"].Value = sqltxt2;

                            var rs2 = new DouImp.Models.FtisModelContext().Database.SqlQuery<cmmEmp>(sqltxt2).ToArray();
                            foreach (var row2 in rs2)
                            { sheet1.Cells["J" + ii].Value = row2.Name; }
                            //rs2.Clear();
                        }
                        else { sheet1.Cells["J" + ii].Value = rows.MNO; }
                        //sheet1.Cells["J" + ii].Value = rows.MNO;

                        sheet1.Cells["K" + ii].Value = rows.PLACE;
                        sheet1.Cells["L" + ii].Value = rows.BUYDATE.GetDateTimeFormats();
                        sheet1.Cells["M" + ii].Value = rows.SPR;
                        sheet1.Cells["N" + ii].Value = rows.EQMONEY;
                        sheet1.Cells["O" + ii].Value = rows.WRTYR;
                        sheet1.Cells["P" + ii].Value = rows.DURYR;

                        if (rows.EDTPSN != "")
                        {
                            var sqltxt3 = @"SELECT * FROM cmmEmp where mno='" + rows.EDTPSN + "' order by mno";
                            //sheet1.Cells["G1"].Value = sqltxt3;

                            var rs3 = new DouImp.Models.FtisModelContext().Database.SqlQuery<cmmEmp>(sqltxt3).ToArray();
                            foreach (var row3 in rs3)
                            { sheet1.Cells["Q" + ii].Value = row3.Name; }
                        }
                        else { sheet1.Cells["Q" + ii].Value = rows.EDTPSN; }
                        //sheet1.Cells["Q" + ii].Value = rows.EDTPSN;

                        sheet1.Cells["R" + ii].Value = rows.MEMO1;
                        sheet1.Cells["S" + ii].Value = rows.EDTTIME.GetDateTimeFormats();
                        sheet1.Cells["T" + ii].Value = rows.IVTDATE;
                        sheet1.Cells["U" + ii].Value = rows.FAULTMEMO;
                        
                        if (rows.SCRDATE!=null)
                        {
                            //sheet1.Cells["V" + ii].Value = rows.SCRDATE.ToShortDateString().ToString();
                            //sheet1.Cells["V" + ii].Value = rows.SCRDATE.ToString("yyyy/MM/dd");
                            sheet1.Cells["V" + ii].Value = rows.SCRDATE.ToString();
                        }

                        sheet1.Cells["W" + ii].Value = rows.MEMO2;
                        //sheet1.Cells["" + ii].Value = rows.;

                        ii++;

                    }


                    //var aa = Convert.ToString(rs1["Mno"]);
                    //sheet1.Cells["S8"].Value = aa;

                    //秀出後端操作者
                    //sheet1.Cells["A1"].Value = UserController.CurrentFtisEmployee.Department.DName;
                    //sheet1.Cells["B1"].Value = UserController.CurrentFtisEmployee.Name;
                    //sheet1.Cells["C1"].Value = "工程師";
                    //sheet1.Cells["D1"].Value = sheet1.Cells["D1"].Value + "[" + tmpaa + "]";


                    //classSession = dataReader["classSession"].ToString();
                    //Id = reader.GetInt32(reader.GetOrdinal("id"))

                    //保存excel
                    ep.Save();

                    rs1.Clear();
                }





                //回傳報表給user
                var rptfilename = new FileStream(file2.FullName, FileMode.Open, FileAccess.Read);
                string contentType = MimeMapping.GetMimeMapping(file2.FullName);
                return File(rptfilename, contentType, file2.Name);
            }
            else
            {
                Response.Write("<script language=javascript>alert('原始檔案不存在!!');</" + "script>");
                return View("Place");
                //return RedirectToAction("Upload");
            }

        }









        protected override IModelEntity<eqEquip> GetModelEntity()
        {
            return new Dou.Models.DB.ModelEntity<eqEquip>(new DouImp.Models.DouModelContextExt());
        }

        //取出特定欄位，自動更新
        protected override void UpdateDBObject(IModelEntity<eqEquip> dbEntity, IEnumerable<eqEquip> objs)
        {
            foreach(var obj in objs) {

                obj.EDTPSN = UserController.CurrentFtisEmployee.Mno;
                obj.EDTTIME = DateTime.Now;

                //測試~可以看不能修改，但後台要自動更新
                //obj.setEDTPSN( UserController.CurrentFtisEmployee.Mno);
                //obj.setEDTTIME(DateTime.Now);            
            }
            dbEntity.Update(objs);
        }
    }
}