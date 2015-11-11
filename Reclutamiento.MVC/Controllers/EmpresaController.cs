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

        public ActionResult Registrar()
        {
            var listaRubros = proxy.ListarRubros();
            ViewBag.Rubros = listaRubros;
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Empresa empresa)
        {
            proxy.CrearEmpresa(empresa.EmailContacto, empresa.Clave, empresa.RazonSocial, empresa.NumeroRuc, empresa.Rubro);
            return RedirectToAction("Index", "Home");
        }

    }
}
