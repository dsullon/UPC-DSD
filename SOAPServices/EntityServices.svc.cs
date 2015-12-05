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
        private UsuarioDAO usuarioDAO = null;
        private UsuarioDAO UsuarioDAO
        {
            get
            {
                if (usuarioDAO == null)
                    usuarioDAO = new UsuarioDAO();
                return usuarioDAO;
            }
        }

        private AnuncioDAO anuncioDAO = null;
        private AnuncioDAO AnuncioDAO
        {
            get
            {
                if (anuncioDAO == null)
                    anuncioDAO = new AnuncioDAO();
                return anuncioDAO;
            }
        }

        private RubroDAO rubroDAO = null;
        private RubroDAO RubroDAO
        {
            get
            {
                if (rubroDAO == null)
                    rubroDAO = new RubroDAO();
                return rubroDAO;
            }
        }

        #region . EMPRESA .

        public void CrearEmpresa(Empresa empresa)
        {
            string BASE_URL2 = "http://ws.razonsocialperu.com/rest/PROYUPC/RUC/";
            string urlConsulta = string.Format("{0}/{1}", BASE_URL2, empresa.NumeroRuc);
            var webClient = new WebClient();
            var json = webClient.DownloadString(urlConsulta);
            var js = new JavaScriptSerializer();
            var result = js.DeserializeObject(json);

            Dictionary<string, object> lista = ((object[])(result))[0] as Dictionary<string, object>;
            var estado = lista.Where(x => x.Key == "status") as Dictionary<string, object>;

            string value = lista["status"].ToString();

            if (value != "EXISTS")
                throw new WebFaultException<string>("El RUC ingresado no se encuentra registrado en los sistemas tributarios.", HttpStatusCode.NotFound);
            var listaEmpresas = ObtenerListadoEmpresa();
            if (listaEmpresas != null && listaEmpresas.Count > 0)
            {
                var empresaExistente = listaEmpresas.Where(c => c.NumeroRuc.Equals(empresa.NumeroRuc)).FirstOrDefault();
                if (empresaExistente != null)
                    throw new WebFaultException<string>("Existe una empresa registrada con el número de R.U.C. ingresado.", HttpStatusCode.Conflict);

                empresaExistente = listaEmpresas.Where(c => c.Email.Equals(empresa.Email)).FirstOrDefault();
                if (empresaExistente != null)
                    throw new WebFaultException<string>("Existe una empresa registrada con el email ingresado.", HttpStatusCode.Conflict);
            }

            UsuarioDAO.Crear(empresa);
            WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Created;
        }

        public void EliminarEmpresa(string id)
        {
            int idEmpresa = int.Parse(id);
            var empresaEncontrada = UsuarioDAO.Obtener(idEmpresa);
            if (empresaEncontrada != null)
                usuarioDAO.Eliminar(empresaEncontrada);
            else
                throw new WebFaultException<string>("Empresa no encontrada.", HttpStatusCode.NotFound);
        }

        public void ModificarEmpresa(Empresa empresa)
        {
            int idEmpresa = empresa.Id;
            var empresaEncontrada = UsuarioDAO.Obtener(idEmpresa);
            if (empresaEncontrada != null)
            {
                usuarioDAO.Modificar(empresa);
            }
            else
                throw new WebFaultException<string>("Empresa no encontrada.", HttpStatusCode.NotFound);

        }

        public List<Empresa> ListarEmpresa()
        {
            var listaEmpresa = ObtenerListadoEmpresa();
            return listaEmpresa;
        }

        private List<Empresa> ObtenerListadoEmpresa()
        {
            var lista = UsuarioDAO.ListarTodos().ToList();
            var listaEmpresa = new List<Empresa>();
            foreach (var item in lista)
            {
                if (item.GetType() == typeof(Empresa))
                    listaEmpresa.Add(item as Empresa);
            }
            return listaEmpresa;
        }


        public Empresa ObtenerEmpresa(string id)
        {
            int idEmpresa = int.Parse(id);
            Empresa empresaEncontrada = UsuarioDAO.Obtener(idEmpresa) as Empresa;
            if (empresaEncontrada != null)
            {
                return empresaEncontrada;
            }
            throw new WebFaultException<string>("La empresa fue eliminada o no ha sido creada", HttpStatusCode.NotFound);
        }

        #endregion

        #region . POSTULANTE .

        public void CrearPostulante(Postulante postulante)
        {
            string BASE_URL2 = "http://ws.razonsocialperu.com/rest/PROYUPC/DNI/";
            string urlConsulta = string.Format("{0}/{1}", BASE_URL2, postulante.Dni);
            var webClient = new WebClient();
            var json = webClient.DownloadString(urlConsulta);
            var js = new JavaScriptSerializer();
            var result = js.DeserializeObject(json);

            Dictionary<string, object> lista = ((object[])(result))[0] as Dictionary<string, object>;
            var estado = lista.Where(x => x.Key == "status") as Dictionary<string, object>;

            string value = lista["status"].ToString();

            if (value != "EXISTS")
                throw new WebFaultException<string>("El DNI ingresado no se encuentra registrado en los sistemas de identificación nacional.", HttpStatusCode.NotFound);
            var listaPostulantes = ObtenerListadoPostulante();
            if (listaPostulantes != null && listaPostulantes.Count > 0)
            {
                var postulanteExistente = listaPostulantes.Where(c => c.Dni.Equals(postulante.Dni)).FirstOrDefault();
                if (postulanteExistente != null)
                    throw new WebFaultException<string>("Existe una postulante registrada con el número de D.N.I. ingresado.", HttpStatusCode.Conflict);

                postulanteExistente = listaPostulantes.Where(c => c.Email.Equals(postulante.Email)).FirstOrDefault();
                if (postulanteExistente != null)
                    throw new WebFaultException<string>("Existe una postulante registrada con el email ingresado.", HttpStatusCode.Conflict);
            }

            UsuarioDAO.Crear(postulante);
            WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Created;
        }

        public void EliminarPostulante(string id)
        {
            int idPostulante = int.Parse(id);
            var postulanteEncontrada = UsuarioDAO.Obtener(idPostulante);
            if (postulanteEncontrada != null)
                usuarioDAO.Eliminar(postulanteEncontrada);
            else
                throw new WebFaultException<string>("Postulante no encontrada.", HttpStatusCode.NotFound);
        }

        public void ModificarPostulante(Postulante postulante)
        {
            int idPostulante = postulante.Id;
            var postulanteEncontrada = UsuarioDAO.Obtener(idPostulante);
            if (postulanteEncontrada != null)
            {
                usuarioDAO.Modificar(postulante);
            }
            else
                throw new WebFaultException<string>("Postulante no encontrada.", HttpStatusCode.NotFound);

        }

        public List<Postulante> ListarPostulante()
        {
            var listaPostulante = ObtenerListadoPostulante();
            return listaPostulante;
        }

        private List<Postulante> ObtenerListadoPostulante()
        {
            var lista = UsuarioDAO.ListarTodos().ToList();
            var listaPostulante = new List<Postulante>();
            foreach (var item in lista)
            {
                if (item.GetType() == typeof(Postulante))
                    listaPostulante.Add(item as Postulante);
            }
            return listaPostulante;
        }

        public Postulante ObtenerPostulante(string id)
        {
            int idPostulante = int.Parse(id);
            Postulante postulanteEncontrada = UsuarioDAO.Obtener(idPostulante) as Postulante;
            if (postulanteEncontrada != null)
            {
                return postulanteEncontrada;
            }
            throw new WebFaultException<string>("La postulante fue eliminada o no ha sido creada", HttpStatusCode.NotFound);
        }

        #endregion

        #region . RUBRO .

        public void CrearRubro(Rubro rubro)
        {
            RubroDAO.Crear(rubro);
            WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Created;
        }

        public void EliminarRubro(string id)
        {
            int idRubro = int.Parse(id);
            var rubroEncontrada = RubroDAO.Obtener(idRubro);
            if (rubroEncontrada != null)
                rubroDAO.Eliminar(rubroEncontrada);
            else
                throw new WebFaultException<string>("Rubro no encontrado.", HttpStatusCode.NotFound);
        }

        public void ModificarRubro(Rubro rubro)
        {
            int idRubro = rubro.Id;
            var rubroEncontrada = RubroDAO.Obtener(idRubro);
            if (rubroEncontrada != null)
            {
                rubroDAO.Modificar(rubro);
            }
            else
                throw new WebFaultException<string>("Rubro no encontrado.", HttpStatusCode.NotFound);

        }

        public List<Rubro> ListarRubro()
        {
            return RubroDAO.ListarTodos().ToList();
        }

        public Rubro ObtenerRubro(string id)
        {
            int idRubro = int.Parse(id);
            var rubroEncontrada = RubroDAO.Obtener(idRubro);
            if (rubroEncontrada != null)
            {
                return rubroEncontrada;
            }
            //throw new WebFaultException<string>("Rubro no encontrada.", HttpStatusCode.NotFound);
            ErrorData error = new ErrorData("Rubro no encontrada.", "El rubro fue eliminado o no ha sido creado");
            throw new WebFaultException<ErrorData>(error, HttpStatusCode.NotFound);
            //WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Rubro no encontada!");
        }

        #endregion

        #region . ANUNCIO .

        public List<Anuncio> ListarAnuncio()
        {
            var listado = AnuncioDAO.ListarTodos().ToList();
            return listado;
        }


        #endregion
    }
}
