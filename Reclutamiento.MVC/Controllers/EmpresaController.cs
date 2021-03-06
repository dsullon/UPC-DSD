﻿using Reclutamiento.MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Reclutamiento.MVC.Controllers
{
    public class EmpresaController : Controller
    {
        string BASE_URL = "http://localhost:40845/EntityServices.svc/";

        //ReclutamientoServiceClient proxy = new ReclutamientoServiceClient();
        // GET: Empresa
        public ActionResult Index()
        {
            //var listaRubros = proxy.ListarRubros();
            var webClient = new WebClient();
            var json = webClient.DownloadString(BASE_URL + "/Empresas");
            var js = new JavaScriptSerializer();
            var listaRubros = js.Deserialize<List<Empresa>>(json);

            ViewBag.Rubros = listaRubros;
            return View();
        }

        //public JsonResult ExisteRUC(string ruc)
        //{
        //    var empresa = proxy.ListarEmpresas().Where(c => c.NumeroRuc.Equals(ruc)).FirstOrDefault();
        //    if (empresa != null)
        //        return new JsonResult { Data = false };
        //    return new JsonResult { Data = true };

        //    //    return Json(true, JsonRequestBehavior.AllowGet);

        //    //return Json("Email address in use", JsonRequestBehavior.AllowGet);

        //}

        //public JsonResult ExisteEmail(string email)
        //{
        //    var empresa = proxy.ListarEmpresas().Where(c => c.EmailContacto.Equals(email)).FirstOrDefault();
        //    if (empresa != null)
        //        return new JsonResult { Data = false };
        //    return new JsonResult { Data = true };
        //}

        public ActionResult Registrar()
        {
            //var listaRubros = proxy.ListarRubros();
            var webClient = new WebClient();
            var json = webClient.DownloadString(BASE_URL + "/Rubros");
            var js = new JavaScriptSerializer();
            //var listaRubros = js.Deserialize<List<Rubro>>(json);
            var listaRubros = new SelectList(js.Deserialize<List<Rubro>>(json), "Id", "Descripcion");

            RegisterViewModel viewModel = new RegisterViewModel();
            ViewBag.ListaRubros = listaRubros;
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Reclutamiento.MVC.Models.Empresa empresa)
        {
            try
            {
                string url = string.Format("{0}/Empresas", BASE_URL);
                var serial = new DataContractJsonSerializer(typeof(Reclutamiento.MVC.Models.Empresa));
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                using (var requestStream = request.GetRequestStream())
                {
                    serial.WriteObject(requestStream, empresa);
                }
                var response = (HttpWebResponse)request.GetResponse();
                var status = response.StatusCode;
                if (status == HttpStatusCode.Created)
                    return RedirectToAction("Listado", "Empresa");
                else
                {
                    ViewBag.Error = TempData["error"];
                    return View();
                }
            }
            catch (WebException ex)
            {
                var json = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                var js = new JavaScriptSerializer();
                var data = js.Deserialize<string>(json);
                ViewBag.Error = TempData["error"];
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(empresa);
            }

            //if (!ValidarRuc(empresa.NumeroRuc))
            //{
            //    "El RUC ingresado no se encuentra registrado en los sistemas tributarios.";
            //}


            //string url = string.Format("{0}/Empresas", BASE_URL);
            ////var r = proxy.ObtenerRubro(rubro);
            ////empresa.Rubro = r;
            //var serial = new DataContractJsonSerializer(typeof(Reclutamiento.MVC.Models.Empresa));
            //var request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "POST";
            //request.ContentType = "application/json";
            //using (var requestStream = request.GetRequestStream())
            //{
            //    serial.WriteObject(requestStream, empresa);
            //}

            //var response = (HttpWebResponse)request.GetResponse();
            //var status = response.StatusCode;
            //if(status==HttpStatusCode.Created)
            //    return RedirectToAction("Index", "Home");
            //else
            //{
            //    ViewBag.Error = TempData["error"];
            //    return View();
            //}
        }

        private static bool ValidarRuc(string ruc)
        {
            string BASE_URL2 = "http://ws.razonsocialperu.com/rest/PROYUPC/RUC/";
            string urlConsulta = string.Format("{0}/{1}", BASE_URL2, ruc);
            var webClient = new WebClient();
            var json = webClient.DownloadString(urlConsulta);
            var js = new JavaScriptSerializer();
            var result = js.DeserializeObject(json);

            Dictionary<string, object> lista = ((object[])(result))[0] as Dictionary<string, object>;
            var estado = lista.Where(x => x.Key == "status") as Dictionary<string, object>;
            string value = lista["status"].ToString();

            bool error = true;
            if (value != "EXISTS")
                error = false;
            return error;
        }

        public ActionResult Editar()
        {
            return View();
        }

        public ActionResult Listado()
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString(BASE_URL + "/Empresas");
            var js = new JavaScriptSerializer();
            var listaEmpresa = js.Deserialize<List<Empresa>>(json);
            return View(listaEmpresa);

            //if (Session["EmpresaId"] != null)
            //{
            //    var resultado = proxy.ListarEmpresas();
            //    return View(resultado);
            //}
            //else
            //    return RedirectToAction("Index", "Empresa");
        }

        public ActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Login(Reclutamiento.MVC.Models.Empresa empresa)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var empresaExistente = proxy.ListarEmpresas().Where(c => c.EmailContacto.Equals(empresa.EmailContacto) && c.Clave.Equals(empresa.Clave)).FirstOrDefault();
        //        if (empresaExistente != null)
        //        {
        //            Session["EmpresaId"] = empresaExistente.Id.ToString();
        //            Session["EmpresaNombre"] = empresaExistente.RazonSocial.ToString();
        //            return RedirectToAction("Listado", "Empresa");
        //        }
        //    }
        //    return View(empresa);
        //}

        [HttpPost]
        public ActionResult LogOff()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }

}