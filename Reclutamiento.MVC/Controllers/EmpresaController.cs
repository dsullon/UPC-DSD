using Reclutamiento.MVC.ReclutamientoWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reclutamiento.MVC.Controllers
{
    public class EmpresaController : Controller
    {
        ReclutamientoServiceClient proxy = new ReclutamientoServiceClient();
        // GET: Empresa
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ExisteRUC(string numeroRUC)
        {
            var empresa = proxy.ListarEmpresas().Where(c => c.NumeroRuc.Equals(numeroRUC)).FirstOrDefault();
            if (empresa != null)
                return new JsonResult { Data = false };
            return new JsonResult { Data = true };

            //    return Json(true, JsonRequestBehavior.AllowGet);

            //return Json("Email address in use", JsonRequestBehavior.AllowGet);

        }

    }


}