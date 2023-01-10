using Dou.Models.DB;
using DouImp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DouImp.Controllers
{
    [Dou.Misc.Attr.MenuDef(Id = "Controlc", Name = "主分類", Index = 3, MenuPath = "", Action = "Index", Func = Dou.Misc.Attr.FuncEnum.ALL, AllowAnonymous = false)]

    public class TypeAController : Dou.Controllers.AGenericModelController<eqTypeA>
    {
        // GET: TypeA
        public ActionResult Index()
        {
            return View();
        }


        protected override IModelEntity<eqTypeA> GetModelEntity()
        {
            return new Dou.Models.DB.ModelEntity<eqTypeA>(new DouImp.Models.DouModelContextExt());
        }

    }
}