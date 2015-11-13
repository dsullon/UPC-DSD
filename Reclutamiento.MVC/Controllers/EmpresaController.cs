﻿using Reclutamiento.MVC.ReclutamientoWS;
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

        public ActionResult Index()
        {
            return View();
        }

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

        public ActionResult Listado() {
            var resultado = proxy.ListarEmpresas();
            return View(resultado);
        }

        [HttpPost]
        public ActionResult Registrar(Empresa empresa)
        {
            var r = new Rubro() { Id = 0 };
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

    }
}
