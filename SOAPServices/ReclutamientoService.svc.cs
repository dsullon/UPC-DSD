using SOAPServices.Dominio;
using SOAPServices.Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOAPServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ReclutamientoService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ReclutamientoService.svc o ReclutamientoService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ReclutamientoService : IReclutamientoService
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

        #region . Rubro .

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

        public Rubro CrearRubro(string descripcion)
        {
            Rubro empresaCrear = new Rubro()
            {
                Descripcion = descripcion
            };
            return RubroDAO.Crear(empresaCrear);
        }

        public Rubro ObtenerRubro(int id)
        {
            return RubroDAO.Obtener(id);
        }

        public Rubro ModificarRubro(int id, string descripcion)
        {
            Rubro empresaModificar = new Rubro()
            {
                Id = id,
                Descripcion = descripcion
            };
            return RubroDAO.Modificar(empresaModificar);
        }

        public void EliminarRubro(int id)
        {
            Rubro empresaExistente = RubroDAO.Obtener(id);
            RubroDAO.Eliminar(empresaExistente);
        }

        public List<Rubro> ListarRubros()
        {
            return RubroDAO.ListarTodos().ToList();
        }

        #endregion

        //#region . Empresa .

        //public OperationStatus CrearEmpresa(string email, string clave, string razonSocial, string numeroRuc, int idRubro)
        //{
        //    try
        //    {
        //        Rubro rubroExistente = RubroDAO.Obtener(idRubro);
        //        Empresa empresaCrear = new Empresa()
        //        {
        //            Email = email,
        //            Clave = clave,
        //            RazonSocial = razonSocial,
        //            NumeroRuc = numeroRuc,
        //            Rubro = rubroExistente
        //        };

        //        var validationContext = new ValidationContext(empresaCrear, serviceProvider: null, items: null);
        //        var validationResults = new List<ValidationResult>();

        //        var isValid = Validator.TryValidateObject(empresaCrear, validationContext, validationResults, true);

        //        if (!isValid)
        //        {
        //            OperationStatus opStatus = new OperationStatus();
        //            opStatus.Success = false;

        //            foreach (ValidationResult message in validationResults)
        //            {
        //                opStatus.Messages.Add(message.ErrorMessage);
        //            }

        //            return opStatus;
        //        }
        //        else
        //        {
        //            UsuarioDAO.Crear(empresaCrear);
        //            return new OperationStatus { Success = true };
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return OperationStatus.CreateFromException("Al crear la empresa.", e);
        //    }
        //}

        //public Empresa ObtenerEmpresa(int id)
        //{
        //    return UsuarioDAO.Obtener(id) as Empresa;
        //}

        //public Empresa ModificarEmpresa(int id, string email, string clave, string razonSocial, string numeroRuc, int idRubro)
        //{
        //    Rubro rubroExistente = RubroDAO.Obtener(idRubro);
        //    Empresa empresaModificar = new Empresa()
        //    {
        //        Id = id,
        //        Email = email,
        //        Clave = clave,
        //        RazonSocial = razonSocial,
        //        NumeroRuc = numeroRuc,
        //        Rubro = rubroExistente
        //    };
        //    return UsuarioDAO.Modificar(empresaModificar) as Empresa;
        //}

        //public void EliminarEmpresa(int id)
        //{
        //    Empresa empresaExistente = UsuarioDAO.Obtener(id) as Empresa;
        //    UsuarioDAO.Eliminar(empresaExistente);
        //}

        //public List<Empresa> ListarEmpresas()
        //{
        //    return (UsuarioDAO.ListarTodos() as List<Empresa>).ToList();
        //}

        //#endregion

        //#region . Postulante .

        //public OperationStatus CrearPostulante(string nombre, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, string email, string dni, string clave)
        //{
        //    try
        //    {
        //        //Rubro rubroExistente = RubroDAO.Obtener(idRubro);
        //        Usuario postulanteCrear = new Postulante()
        //        {
        //            Nombre = nombre,
        //            ApellidoPaterno = apellidoPaterno,
        //            ApellidoMaterno = apellidoMaterno,
        //            FechaNacimiento = fechaNacimiento,
        //            //email = email,
        //            Dni = dni,
        //            //clave = clave
        //        };

        //        var validationContext = new ValidationContext(postulanteCrear, serviceProvider: null, items: null);
        //        var validationResults = new List<ValidationResult>();

        //        var isValid = Validator.TryValidateObject(postulanteCrear, validationContext, validationResults, true);

        //        if (!isValid)
        //        {
        //            OperationStatus opStatus = new OperationStatus();
        //            opStatus.Success = false;

        //            foreach (ValidationResult message in validationResults)
        //            {
        //                opStatus.Messages.Add(message.ErrorMessage);
        //            }

        //            return opStatus;
        //        }
        //        else
        //        {
        //            UsuarioDAO.Crear(postulanteCrear);
        //            return new OperationStatus { Success = true };
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return OperationStatus.CreateFromException("Al crear al postulante.", e);
        //    }
        //}

        //public Postulante ObtenerPostulante(int id)
        //{
        //    return UsuarioDAO.Obtener(id) as Postulante;
        //}

        //public Postulante ModificarPostulante(int idPostulante, string nombre, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, string email, string dni, string clave)
        //{
        //    //Rubro rubroExistente = RubroDAO.Obtener(idRubro);
        //    Usuario postulanteModificar = new Postulante()
        //    {
        //        //idPostulante = idPostulante,
        //        Nombre = nombre,
        //        ApellidoPaterno = apellidoPaterno,
        //        ApellidoMaterno = apellidoMaterno,
        //        FechaNacimiento = fechaNacimiento,
        //        //email = email,
        //        Dni = dni,
        //        //clave = clave
        //        //Rubro = rubroExistente
        //    };
        //    return UsuarioDAO.Modificar(postulanteModificar) as Postulante;
        //}

        //public void EliminarPostulante(int id)
        //{
        //    var postulanteExistente = UsuarioDAO.Obtener(id);
        //    UsuarioDAO.Eliminar(postulanteExistente);
        //}

        //public List<Postulante> ListarPostulante()
        //{
        //    return (UsuarioDAO.ListarTodos() as List<Postulante>).ToList();
        //}

        //#endregion

        #region . Aptitud .

        private AptitudDAO aptitudDAO = null;
        private AptitudDAO AptitudDAO
        {
            get
            {
                if (aptitudDAO == null)
                    aptitudDAO = new AptitudDAO();
                return aptitudDAO;
            }
        }

        public Aptitud CrearAptitud(string descripcion)
        {
            Aptitud aptitudCrear = new Aptitud()
            {
                Descripcion = descripcion
            };
            return AptitudDAO.Crear(aptitudCrear);
        }

        public Aptitud ObtenerAptitud(int id)
        {
            return AptitudDAO.Obtener(id);
        }

        public Aptitud ModificarAptitud(int id, string descripcion)
        {
            Aptitud aptitudModificar = new Aptitud()
            {
                Id = id,
                Descripcion = descripcion
            };
            return AptitudDAO.Modificar(aptitudModificar);
        }

        public void EliminarAptitud(int id)
        {
            Aptitud aptitudExistente = AptitudDAO.Obtener(id);
            AptitudDAO.Eliminar(aptitudExistente);
        }

        public List<Aptitud> ListarAptitudes()
        {
            return AptitudDAO.ListarTodos().ToList();
        }

        #endregion

        #region . Anuncio .

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

        public OperationStatus CrearAnuncio(string titulo, string descripcion)
        {
            try
            {
                //Aptitud aptitudesExistentes = AptitudDAO.ListarTodos;
                Anuncio anuncioCrear = new Anuncio()
                {
                    Titulo = titulo,
                    Descripcion = descripcion,
                };

                var validationContext = new ValidationContext(anuncioCrear, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();

                var isValid = Validator.TryValidateObject(anuncioCrear, validationContext, validationResults, true);

                if (!isValid)
                {
                    OperationStatus opStatus = new OperationStatus();
                    opStatus.Success = false;

                    foreach (ValidationResult message in validationResults)
                    {
                        opStatus.Messages.Add(message.ErrorMessage);
                    }

                    return opStatus;
                }
                else
                {
                    AnuncioDAO.Crear(anuncioCrear);
                    return new OperationStatus { Success = true };
                }
            }
            catch (Exception e)
            {
                return OperationStatus.CreateFromException("Al crear el anuncio.", e);
            }
        }

        public Anuncio ObtenerAnuncio(int id)
        {
            return AnuncioDAO.Obtener(id);
        }

        public Anuncio ModificarAnuncio(int id, string titulo, string descripcion)
        {
            //Aptitud aptitudExistente = AptitudDAO.Obtener(aptitud);
            Anuncio anuncioModificar = new Anuncio()
            {
                Id = id,
                Titulo = titulo,
                Descripcion = descripcion,
            };
            return AnuncioDAO.Modificar(anuncioModificar);
        }

        public void EliminarAnuncio(int id)
        {
            Anuncio anuncioExistente = AnuncioDAO.Obtener(id);
            AnuncioDAO.Eliminar(anuncioExistente);
        }

        public List<Anuncio> ListarAnuncios()
        {
            return AnuncioDAO.ListarTodos().ToList();
        }

        #endregion

        #region . Aptitud_Anuncio .

        private Aptitud_AnuncioDAO aptitud_anuncioDAO = null;
        private Aptitud_AnuncioDAO Aptitud_AnuncioDAO
        {
            get
            {
                if (aptitud_anuncioDAO == null)
                    aptitud_anuncioDAO = new Aptitud_AnuncioDAO();
                return aptitud_anuncioDAO;
            }
        }

        public Aptitud_Anuncio CrearAptitud_Anuncio(int idanuncio, int idaptitud)
        {
            Aptitud_Anuncio aptitud_anuncioCrear = new Aptitud_Anuncio()
            {
                IdAnuncio = idanuncio,
                IdAptitud = idaptitud
            };
            return Aptitud_AnuncioDAO.Crear(aptitud_anuncioCrear);
        }

        public Aptitud_Anuncio ObtenerAptitud_Anuncio(int id)
        {
            return Aptitud_AnuncioDAO.Obtener(id);
        }

        public Aptitud_Anuncio ModificarAptitud_Anuncio(int idanuncio, int idaptitud)
        {
            Aptitud_Anuncio aptitud_anuncioModificar = new Aptitud_Anuncio()
            {
                IdAnuncio = idanuncio,
                IdAptitud = idaptitud
            };
            return Aptitud_AnuncioDAO.Modificar(aptitud_anuncioModificar);
        }

        public void EliminarAptitud_Anuncio(int id)
        {
            Aptitud_Anuncio aptitud_anuncioExistente = Aptitud_AnuncioDAO.Obtener(id);
            Aptitud_AnuncioDAO.Eliminar(aptitud_anuncioExistente);
        }

        public List<Aptitud_Anuncio> ListarAptitudesPorAnuncio()
        {
            return Aptitud_AnuncioDAO.ListarTodos().ToList();
        }

        #endregion
    }
}
