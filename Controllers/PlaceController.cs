using Dou.Models.DB;
using DouImp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DouImp.Controllers
{
    [Dou.Misc.Attr.MenuDef(Id = "Controlb", Name = "地點", Index =2 , MenuPath = "", Action = "Index", Func = Dou.Misc.Attr.FuncEnum.ALL, AllowAnonymous = false)]

    public class PlaceController : Dou.Controllers.AGenericModelController<eqPlace>
    {
        // GET: Place
        public ActionResult Index()
        {
            return View();
        }


        protected override IModelEntity<eqPlace> GetModelEntity()
        {
            return new Dou.Models.DB.ModelEntity<eqPlace>(new DouImp.Models.DouModelContextExt());
        }

    }
}