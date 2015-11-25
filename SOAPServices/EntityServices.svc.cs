using SOAPServices.Dominio;
using SOAPServices.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;

namespace SOAPServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "EntityServices" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione EntityServices.svc o EntityServices.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class EntityServices : IEntityServices
    {
        private EmpresaDAO empresaDAO = null;
        private EmpresaDAO EmpresaDAO
        {
            get
            {
                if (empresaDAO == null)
                    empresaDAO = new EmpresaDAO();
                return empresaDAO;
            }
        }

        #region . EMPRESA .

        public void CrearEmpresa(Empresa empresa)
        {
            //string BASE_URL2 = "http://ws.razonsocialperu.com/rest/PROYUPC/RUC/";
            //string urlConsulta = string.Format("{0}/{1}", BASE_URL2, empresa.NumeroRuc);
            //var webClient = new WebClient();
            //var json = webClient.DownloadString(urlConsulta);
            //var js = new JavaScriptSerializer();
            //var result = js.DeserializeObject(json);

            //Dictionary<string, object> lista = ((object[])(result))[0] as Dictionary<string, object>;
            //var estado = lista.Where(x => x.Key == "status") as Dictionary<string, object>;

            //string value = lista["status"].ToString();

            //if (value != "EXISTS")
            //    throw new WebFaultException<string>("El RUC ingresado no se encuentra registrado en los sistemas tributarios.", HttpStatusCode.NotFound);

            EmpresaDAO.Crear(empresa);
            WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Created;
        }

        public void EliminarEmpresa(string id)
        {
            int idEmpresa = int.Parse(id);
            var empresaEncontrada = EmpresaDAO.Obtener(idEmpresa);
            if (empresaEncontrada != null)
                empresaDAO.Eliminar(empresaEncontrada);
            else
                throw new WebFaultException<string>("Empresa no encontrada.", HttpStatusCode.NotFound);
        }

        public void ModificarEmpresa(Empresa empresa)
        {
            int idEmpresa = empresa.Id;
            var empresaEncontrada = EmpresaDAO.Obtener(idEmpresa);
            if (empresaEncontrada != null)
            {
                empresaDAO.Modificar(empresa);
            }
            else
                throw new WebFaultException<string>("Empresa no encontrada.", HttpStatusCode.NotFound);

        }

        public List<Empresa> ListarEmpresa()
        {
            return EmpresaDAO.ListarTodos().ToList();
        }

        public Empresa ObtenerEmpresa(string id)
        {
            int idEmpresa = int.Parse(id);
            var empresaEncontrada = EmpresaDAO.Obtener(idEmpresa);
            if (empresaEncontrada != null)
            {
                return empresaEncontrada;
            }
            //throw new WebFaultException<string>("Empresa no encontrada.", HttpStatusCode.NotFound);
            ErrorData error = new ErrorData("Empresa no encontrada.", "La empresa fue eliminada o no ha sido creada");
            throw new WebFaultException<ErrorData>(error, HttpStatusCode.NotFound);
            //WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Empresa no encontada!");
            return null;
        }

        #endregion


    }
}
