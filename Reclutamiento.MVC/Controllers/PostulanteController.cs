using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reclutamiento.MVC.Controllers
{
    public class PostulanteController : Controller
    {
        //ReclutamientoServiceClient proxy = new ReclutamientoServiceClient();
        //// GET: Postulante
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public JsonResult ExisteDNI(string dni)
        //{
        //    var postulante = proxy.ListarPostulante().Where(c => c.dni.Equals(dni)).FirstOrDefault();
        //    if (postulante != null)
        //        return new JsonResult { Data = false };
        //    return new JsonResult { Data = true };

        //    //    return Json(true, JsonRequestBehavior.AllowGet);

        //    //return Json("Email address in use", JsonRequestBehavior.AllowGet);

        //}

        //public JsonResult ExisteEmail(string email)
        //{
        //    var postulante = proxy.ListarPostulante().Where(c => c.email.Equals(email)).FirstOrDefault();
        //    if (postulante != null)
        //        return new JsonResult { Data = false };
        //    return new JsonResult { Data = true };
        //}

        //[HttpPost]
        //public ActionResult Registrar(Postulante postulante)
        //{
        //    //var r = proxy.ObtenerRubro(rubro);
        //    OperationStatus opStatus = proxy.CrearPostulante(postulante.nombre, postulante.apellidoPaterno, postulante.apellidoMaterno, postulante.fechaNacimiento, postulante.email, postulante.dni, postulante.clave);
        //    return Json(opStatus);
            
        //}

        //public ActionResult Editar()
        //{
        //    return View();
        //}

        //public ActionResult Listado()
        //{
        //   var resultado = proxy.ListarPostulante();
        //        return View(resultado);
        //}


        //[HttpPost]
        //public ActionResult Login(Postulante postulante)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var postulanteExistente = proxy.ListarPostulante().Where(c => c.email.Equals(postulante.email) && c.clave.Equals(postulante.clave)).FirstOrDefault();
        //        if (postulanteExistente != null)
        //        {
        //            Session["PostulanteId"] = postulanteExistente.idPostulante.ToString();
        //            Session["PostulanteNombre"] = postulanteExistente.nombre.ToString();
        //            return RedirectToAction("Listado", "Postulante");
        //        }
        //    }
        //    return View(postulante);
        //}

        //[HttpPost]
        //public ActionResult LogOff()
        //{
        //    Session.Abandon();
        //    return RedirectToAction("Index", "Home");
        //}

    }
}