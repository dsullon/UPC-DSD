using Reclutamiento.MVC.ReclutamientoWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reclutamiento.MVC.Controllers
{
    public class RubroController : Controller
    {
        ReclutamientoServiceClient proxy = new ReclutamientoServiceClient();
        //
        // GET: /Rubro/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Rubro rubro)
        {
            proxy.CrearRubro(rubro.Descripcion);
            return RedirectToAction("Listar", "Rubro");
        }

        public ActionResult Listar()
        {
            var listado = proxy.ListarRubros();
            return View(listado);
        }


    }
}
