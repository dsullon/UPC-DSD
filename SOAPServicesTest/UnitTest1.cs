using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using SOAPServices.Dominio;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace SOAPServicesTest
{
    [TestClass]
    public class UnitTest1
    {
        string BASE_URL = "http://reclutamientoupc.azurewebsites.net/entityservices.svc";
        [TestMethod]
        public void ObtenerListadoDeEmpresas()
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString(BASE_URL + "/Empresas");
            var js = new JavaScriptSerializer();
            var lista = js.Deserialize<List<Empresa>>(json);
        }

        [TestMethod]
        public void BuscarEmpresa()
        {
            string url = string.Format("{0}/Empresas/{1}", BASE_URL, 11);
            var webClient = new WebClient();
            var json = webClient.DownloadString(url);
            var js = new JavaScriptSerializer();
            var empresa = js.Deserialize<Empresa>(json);
            Assert.AreEqual("10203456780", empresa.NumeroRuc);
        }

        [TestMethod]
        public void BuscarEmpresaNoExiste()
        {
            try
            {
                string url = string.Format("{0}/Empresas/{1}", BASE_URL, 12);
                var webClient = new WebClient();
                var json = webClient.DownloadString(url);
                var js = new JavaScriptSerializer();
                var empresa = js.Deserialize<Empresa>(json);
            }
            catch (WebException ex)
            {
                    var json = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                    var js = new JavaScriptSerializer();
                    var data = js.Deserialize<ErrorData>(json);
                    Assert.AreEqual("Empresa no encontrada.", data.Motivo);

                //var json = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                //var js = new JavaScriptSerializer();
                //var data = js.Deserialize<string>(json);
                //Assert.AreEqual("Empresa no encontrada.", data);
            }
        }

        [TestMethod]
        public void CrearEmpresa()
        {
            try
            {
            string url = string.Format("{0}/Empresas", BASE_URL);
            Rubro rubro = new Rubro() { Id = 22, Descripcion = "Tecnología y sistemas" };
            Empresa empresa = new Empresa()
            {
                Id = 193,
                EmailContacto = "troinformes@reclutamiento.pe",
                Clave = "D12345678",
                NumeroRuc = "11111111111",
                RazonSocial = "Sistemas",
                Rubro = rubro
            };

            var serial = new DataContractJsonSerializer(typeof(Empresa));
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            using (var requestStream = request.GetRequestStream())
            {
                serial.WriteObject(requestStream, empresa);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var status = response.StatusCode;
            Assert.AreEqual(HttpStatusCode.Created, status);
            }
            catch (WebException ex)
            {
                var json = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                var js = new JavaScriptSerializer();
                var data = js.Deserialize<string>(json);
                Assert.AreEqual("Empresa no encontrada.", data);
            }
        }

        [TestMethod]
        public void ModificarEmpresa()
        {
            try
            {
                string url = string.Format("{0}/Empresas", BASE_URL);
                Rubro rubro = new Rubro() { Id = 22, Descripcion = "Tecnología y sistemas" };
                Empresa empresa = new Empresa()
                {
                    Id = 193,
                    EmailContacto = "informes@reclutamiento.pe",
                    Clave = "123456",
                    NumeroRuc = "12345658909",
                    RazonSocial = "Otra prueba",
                    Rubro = rubro
                };

                var serial = new DataContractJsonSerializer(typeof(Empresa));
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "PUT";
                request.ContentType = "application/json";
                using (var requestStream = request.GetRequestStream())
                {
                    serial.WriteObject(requestStream, empresa);
                }
                var response = (HttpWebResponse)request.GetResponse();
                var status = response.StatusCode;
                Assert.AreEqual(HttpStatusCode.OK, status);
            }
            catch (WebException ex)
            {
                var json = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                var js = new JavaScriptSerializer();
                var data = js.Deserialize<string>(json);
                Assert.AreEqual("Empresa no encontrada.", data);
            }
        }

        [TestMethod]
        public void EliminarEmpresa()
        {
            try
            {
                string url = string.Format("{0}/Empresas/{1}", BASE_URL, 161);
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "DELETE";
                request.ContentType = "application/json";
                HttpWebResponse resp = request.GetResponse() as HttpWebResponse;
                var response = (HttpWebResponse)request.GetResponse();
                var status = response.StatusCode;
                Assert.AreEqual(HttpStatusCode.OK, status);
            }
            catch (WebException ex)
            {
                var json = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                var js = new JavaScriptSerializer();
                var data = js.Deserialize<string>(json);
                Assert.AreEqual("Empresa no encontrada.", data);
            }
        }
    }

    public class Test
    {
        public string field1 { get; set; }
        public string field2 { get; set; }
    } 
}
