using Reclutamiento.MVC.Models;
using Reclutamiento.MVC.ReclutamientoWS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Reclutamiento.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        string BASE_URL = "http://localhost:40845/EntityServices.svc/";


        // GET: Usuario
        public ActionResult RegistrarEmpresa()
        {
            RegistrarEmpresa empresa = new RegistrarEmpresa();
            AsignarRubros(empresa);
            return View(empresa);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarEmpresa(RegistrarEmpresa model)
        {
            if (ModelState.IsValid)
            {
                string urlRubro = string.Format("{0}/Rubros/{1}", Generico.UrlServicioRest, model.RubroID);
                var webClient = new WebClient();
                var json = webClient.DownloadString(urlRubro);
                var js = new JavaScriptSerializer();
                var rubro = js.Deserialize<Rubro>(json);
                var empresa = new Empresa { NumeroRuc = model.NumeroRuc, RazonSocial = model.RazonSocial, Email = model.EmailContacto, Clave = model.Password, Rubro = rubro };

                try
                {
                    string urlEmpresa = string.Format("{0}/Empresas", Generico.UrlServicioRest);
                    var serial = new DataContractJsonSerializer(typeof(Empresa));
                    var request = (HttpWebRequest)WebRequest.Create(urlEmpresa);
                    request.Method = "POST";
                    request.ContentType = "application/json";
                    using (var requestStream = request.GetRequestStream())
                    {
                        serial.WriteObject(requestStream, empresa);
                    }
                    var response = (HttpWebResponse)request.GetResponse();
                    var status = response.StatusCode;
                    if (status == HttpStatusCode.Created)
                    {
                        var fromAddress = new MailAddress("alex.sullonporras@gmail.com", "Trabajorum.PE");
                        var toAddress = new MailAddress(model.EmailContacto, model.RazonSocial);
                        const string fromPassword = "d9900221662";
                        const string subject = "Registro";
                        const string body = "Gracias por registrate";

                        var smtp = new SmtpClient
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                        };
                        using (var message = new MailMessage(fromAddress, toAddress)
                        {
                            Subject = subject,
                            Body = body
                        })
                        {
                            smtp.Send(message);
                        }
                        Session["Empresa"] = empresa;
                        return RedirectToAction("ListarAnuncio", "Empresa");
                    }
                    else
                    {
                        ViewBag.Error = TempData["error"];
                        return View();
                    }
                }
                catch (WebException ex)
                {
                    json = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                    js = new JavaScriptSerializer();
                    var data = js.Deserialize<string>(json);
                    ViewBag.Error = TempData["error"];
                    ModelState.AddModelError(string.Empty, data);
                    AsignarRubros(model);
                    return View(model);
                }
                catch (Exception)
                {
                    //ESCRIBIR COLA
                    string rutaCola = @".\private$\Empresa";
                    if (!MessageQueue.Exists(rutaCola))
                        MessageQueue.Create(rutaCola);
                    MessageQueue cola = new MessageQueue(rutaCola);
                    Message mensaje = new Message();
                    mensaje.Label = "Registro existente";
                    mensaje.Body = new Empresa()
                    {
                        NumeroRuc = model.NumeroRuc,
                        RazonSocial = model.RazonSocial,
                        Rubro = rubro,
                        Email = model.EmailContacto,
                        Clave = model.Password
                    };
                    cola.Send(mensaje);
                }
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        private static void AsignarRubros(RegistrarEmpresa empresa)
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString(Generico.UrlServicioRest + "/Rubros");
            var js = new JavaScriptSerializer();
            var listaRubros = new SelectList(js.Deserialize<List<Rubro>>(json), "Id", "Descripcion");
            empresa.Rubros = listaRubros;
        }

        public ActionResult LoginEmpresa()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginEmpresa(InicioSesionViewModel login)
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString(BASE_URL + "/Empresas");
            var js = new JavaScriptSerializer();
            var listaEmpresa = js.Deserialize<List<Empresa>>(json);

            if (ModelState.IsValid)
            {
                var empresaExistente = listaEmpresa.Where(c => c.Email.Equals(login.Email) && c.Clave.Equals(login.Password)).FirstOrDefault();
                if (empresaExistente != null)
                {
                    Session["Empresa"] = empresaExistente;
                    return RedirectToAction("ListarAnuncio", "Empresa");
                }
            }
            return View(login);

        }

        public ActionResult RegistrarPostulante()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarPostulante(RegistrarPostulante model)
        {
            if (ModelState.IsValid)
            {
                var postulante = new Postulante
                {
                    Dni = model.Dni,
                    Nombre = model.Nombres,
                    ApellidoPaterno = model.ApellidoPaterno,
                    ApellidoMaterno = model.ApellidoMaterno,
                    FechaNacimiento = model.FechaNacimiento,
                    Email = model.EmailContacto,
                    Clave = model.Password
                };

                try
                {
                    string urlPostulante = string.Format("{0}/Postulantes", Generico.UrlServicioRest);
                    var serial = new DataContractJsonSerializer(typeof(Postulante));
                    var request = (HttpWebRequest)WebRequest.Create(urlPostulante);
                    request.Method = "POST";
                    request.ContentType = "application/json";
                    using (var requestStream = request.GetRequestStream())
                    {
                        serial.WriteObject(requestStream, postulante);
                    }
                    var response = (HttpWebResponse)request.GetResponse();
                    var status = response.StatusCode;
                    if (status == HttpStatusCode.Created)
                    {
                        var fromAddress = new MailAddress("alex.sullonporras@gmail.com", "Trabajorum.PE");
                        var toAddress = new MailAddress(model.EmailContacto, string.Format("{0} {1} {2}", model.Nombres, model.ApellidoPaterno, model.ApellidoMaterno));
                        const string fromPassword = "d9900221662";
                        const string subject = "Registro";
                        const string body = "Gracias por registrate";

                        var smtp = new SmtpClient
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                        };
                        using (var message = new MailMessage(fromAddress, toAddress)
                        {
                            Subject = subject,
                            Body = body
                        })
                        {
                            smtp.Send(message);
                        }
                        Session["Postulante"] = postulante;
                        return RedirectToAction("ListarAnuncioUsuario", "Empresa");
                    }
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
                    ModelState.AddModelError(string.Empty, data);
                    return View(model);
                }
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        public ActionResult LoginPostulante()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginPostulante(InicioSesionViewModel login)
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString(BASE_URL + "/Postulantes");
            var js = new JavaScriptSerializer();
            var listaPostulante = js.Deserialize<List<Postulante>>(json);

            if (ModelState.IsValid)
            {
                var empresaExistente = listaPostulante.Where(c => c.Email.Equals(login.Email) && c.Clave.Equals(login.Password)).FirstOrDefault();
                if (empresaExistente != null)
                {
                    Session["Postulante"] = empresaExistente;
                    return RedirectToAction("ListarAnuncioUsuario", "Empresa");
                }
            }
            return View(login);

        }

        [HttpPost]
        public ActionResult LogOff()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}