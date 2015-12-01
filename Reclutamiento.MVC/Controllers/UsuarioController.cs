using Reclutamiento.MVC.Models;
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

                var empresa = new Empresa { NumeroRuc = model.NumeroRuc, RazonSocial = model.RazonSocial, EmailContacto = model.EmailContacto, Clave = model.Password, Rubro = rubro };

                try
                {
                    string urlEmpresa = string.Format("{0}/Empresas", Generico.UrlServicioRest);
                    var serial = new DataContractJsonSerializer(typeof(Reclutamiento.MVC.Models.Empresa));
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
                        //string from = "alex.sullonporras@gmail.com";
                        //var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                        //var message = new MailMessage();
                        //message.To.Add(new MailAddress(model.EmailContacto));  // replace with valid value 
                        //message.From = new MailAddress(from);  // replace with valid value
                        //message.Subject = "Your email subject";
                        //message.Body = string.Format(body, "Alex Sullon Porras", from, "Gracias popr registrarte en el sitio web");
                        //message.IsBodyHtml = true;

                        //using (var smtp = new SmtpClient())
                        //{
                        //    var credential = new NetworkCredential
                        //    {
                        //        UserName = from,  // replace with valid value
                        //        Password = "d9900221662"  // replace with valid value
                        //    };
                        //    smtp.Credentials = credential;
                        //    smtp.Host = "smtp.gmail.com";
                        //    smtp.Port = 587;
                        //    smtp.EnableSsl = true;
                        //    smtp.SendMailAsync(message);
                        //    //return RedirectToAction("Sent");
                        //    return RedirectToAction("Listado", "Empresa");
                        //}
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


                //var result = await UserManager.CreateAsync(user, model.Password);
                //if (result.Succeeded)
                //{
                //    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                //    // Para obtener más información sobre cómo habilitar la confirmación de cuenta y el restablecimiento de contraseña, visite http://go.microsoft.com/fwlink/?LinkID=320771
                //    // Enviar correo electrónico con este vínculo
                //    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                //    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                //    // await UserManager.SendEmailAsync(user.Id, "Confirmar cuenta", "Para confirmar la cuenta, haga clic <a href=\"" + callbackUrl + "\">aquí</a>");

                //    return RedirectToAction("Index", "Home");
                //}
                //AddErrors(result);
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