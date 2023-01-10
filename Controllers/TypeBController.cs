using Dou.Models.DB;
using DouImp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DouImp.Controllers
{
    [Dou.Misc.Attr.MenuDef(Id = "Controld", Name = "次分類", Index = 4, MenuPath = "", Action = "Index", Func = Dou.Misc.Attr.FuncEnum.ALL, AllowAnonymous = false)]

    public class TypeBController : Dou.Controllers.AGenericModelController<eqTypeB>
    {
        // GET: TypeB
        public ActionResult Index()
        {
            return View();
        }


        protected override IModelEntity<eqTypeB> GetModelEntity()
        {
            return new Dou.Models.DB.ModelEntity<eqTypeB>(new DouImp.Models.DouModelContextExt());
        }

    }
}