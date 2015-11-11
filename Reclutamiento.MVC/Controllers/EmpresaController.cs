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
            //ViewData["Rubros"] =
            //    from p in listaRubros
            //    select new SelectListItem
            //    {
            //        Text = p.Descripcion,
            //        Value = p.Id.ToString()
            //    };

            //ViewData["Rubros"] = listaRubros;
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Empresa empresa)
        {
            OperationStatus opStatus = proxy.CrearEmpresa(empresa.EmailContacto, empresa.Clave, empresa.RazonSocial, empresa.NumeroRuc, empresa.Rubro.Id);
            return Json(opStatus);
            //var result = proxy.CrearEmpresa(empresa.EmailContacto, empresa.Clave, empresa.RazonSocial, empresa.NumeroRuc, empresa.Rubro.Id);
            //if (result.Success)
            //    return RedirectToAction("Index", "Home");
            //else
            //{
            //    ViewBag.Error = TempData["error"];
            //    return View();
            //}
        }

    }
}
