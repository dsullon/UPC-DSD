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
        string BASE_URL = "http://localhost:40845/EntityServices.svc/";
        [TestMethod]
        public void ObtenerListadoDeEmpresas()
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString(BASE_URL + "/Empresas");
            var js = new JavaScriptSerializer();
            var lista = js.Deserialize<List<Empresa>>(json);
        }

        [TestMethod]
        public void ObtenerEmpresa()
        {
            string url = string.Format("{0}/Empresas/{1}", BASE_URL, 11);
            var webClient = new WebClient();
            var json = webClient.DownloadString(url);
            var js = new JavaScriptSerializer();
            var empresa = js.Deserialize<Empresa>(json);
        }

        //[TestMethod]
        //public void CrearEmpresa()
        //{
        //    string url = string.Format("{0}/Empresas", BASE_URL);

        //    Rubro rubro = new Rubro() { Id = 22, Descripcion = "Tecnología y sistemas" };
        //    Empresa empresa = new Empresa()
        //    {
        //        EmailContacto = "jjsjsjs@pradspoldueba.pe",
        //        Clave = "123456",
        //        NumeroRuc = "12345658909",
        //        RazonSocial = "Prddduebaaaaa",
        //        Rubro = rubro
        //    };

        //    DataContractJsonSerializer serial = new DataContractJsonSerializer(typeof(Empresa));
        //    MemoryStream mem = new MemoryStream();
        //    serial.WriteObject(mem, empresa);
        //    string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
        //    WebClient webCient = new WebClient();
        //    webCient.Headers["Content-type"] = "application/json";
        //    webCient.Encoding = Encoding.UTF8;
        //    webCient.UploadString(url, "POST", data);
        //}

        [TestMethod]
        public void ModificarEmpresa()
        {
            string url = string.Format("{0}/Empresas", BASE_URL);
            Rubro rubro = new Rubro() { Id = 22, Descripcion = "Tecnología y sistemas" };
            Empresa empresa = new Empresa()
            {
                Id = 251,
                EmailContacto = "jjsjsjs@pradspoldueba.pe",
                Clave = "123456",
                NumeroRuc = "12345658909",
                RazonSocial = "Otro Gaaaatoo",
                Rubro = rubro
            };

            DataContractJsonSerializer serial = new DataContractJsonSerializer(typeof(Empresa));
            MemoryStream mem = new MemoryStream();
            serial.WriteObject(mem, empresa);
            string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
            WebClient webCient = new WebClient();
            webCient.Headers["Content-type"] = "application/json";
            webCient.Encoding = Encoding.UTF8;
            webCient.UploadString(url, "PUT", data);
        }

        [TestMethod]
        public void EliminarEmpresa()
        {
            string url = string.Format("{0}/Empresas", BASE_URL);
            Rubro rubro = new Rubro() { Id = 22, Descripcion = "Tecnología y sistemas" };
            Empresa empresa = new Empresa()
            {
                Id = 251,
                EmailContacto = "jjsjsjs@pradspoldueba.pe",
                Clave = "123456",
                NumeroRuc = "12345658909",
                RazonSocial = "Otro Gaaaatoo",
                Rubro = rubro
            };

            DataContractJsonSerializer serial = new DataContractJsonSerializer(typeof(Empresa));
            MemoryStream mem = new MemoryStream();
            serial.WriteObject(mem, empresa);
            string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
            WebClient webCient = new WebClient();
            webCient.Headers["Content-type"] = "application/json";
            webCient.Encoding = Encoding.UTF8;
            webCient.UploadString(url, "DELETE", data);
        }
    }
}
