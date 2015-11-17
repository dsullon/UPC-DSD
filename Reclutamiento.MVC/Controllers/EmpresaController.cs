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
            var listaRubros = proxy.ListarRubros();
            ViewBag.Rubros = listaRubros;
            return View();
        }

        public JsonResult ExisteRUC(string ruc)
        {
            var empresa = proxy.ListarEmpresas().Where(c => c.NumeroRuc.Equals(ruc)).FirstOrDefault();
            if (empresa != null)
                return new JsonResult { Data = false };
            return new JsonResult { Data = true };

            //    return Json(true, JsonRequestBehavior.AllowGet);

            //return Json("Email address in use", JsonRequestBehavior.AllowGet);

        }

        public JsonResult ExisteEmail(string email)
        {
            var empresa = proxy.ListarEmpresas().Where(c => c.EmailContacto.Equals(email)).FirstOrDefault();
            if (empresa != null)
                return new JsonResult { Data = false };
            return new JsonResult { Data = true };
        }

        public ActionResult Registrar()
        {
            var listaRubros = proxy.ListarRubros();
            ViewBag.Rubros = listaRubros;
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Empresa empresa, int rubro)
        {
            var r = proxy.ObtenerRubro(rubro);
            //OperationStatus opStatus = proxy.CrearEmpresa(empresa.EmailContacto, empresa.Clave, empresa.RazonSocial, empresa.NumeroRuc, empresa.Rubro.Id);
            OperationStatus opStatus = proxy.CrearEmpresa(empresa.EmailContacto, empresa.Clave, empresa.RazonSocial, empresa.NumeroRuc, r.Id);
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

        public ActionResult Listado()
        {
            var resultado = proxy.ListarEmpresas();
            return View(resultado);
        }
    }

}