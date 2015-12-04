using Reclutamiento.MVC.Models;
using Reclutamiento.MVC.ReclutamientoWS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                        return RedirectToAction("Principal", "Empresa");
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
    }
}