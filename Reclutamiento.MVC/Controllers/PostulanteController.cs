using Reclutamiento.MVC.ReclutamientoWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reclutamiento.MVC.Controllers
{
    public class PostulanteController : Controller
    {
        ReclutamientoServiceClient proxy = new ReclutamientoServiceClient();
        // GET: Postulante
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ExisteDNI(string dni)
        {
            var postulante = proxy.ListarPostulante().Where(c => c.NumeroDNI.Equals(dni)).FirstOrDefault();
            if (postulante != null)
                return new JsonResult { Data = false };
            return new JsonResult { Data = true };

            //    return Json(true, JsonRequestBehavior.AllowGet);

            //return Json("Email address in use", JsonRequestBehavior.AllowGet);

        }
    }
}