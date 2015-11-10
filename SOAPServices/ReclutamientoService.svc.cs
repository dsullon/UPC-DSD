using SOAPServices.Dominio;
using SOAPServices.Persistencia;
using System;
using System.Collections.Generic;
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
            Rubro usuarioCrear = new Rubro()
            {
                Descripcion  = descripcion
            };
            return RubroDAO.Crear(usuarioCrear);
        }

        public Rubro ObtenerRubro(int id)
        {
            return RubroDAO.Obtener(id);
        }

        public Rubro ModificarRubro(int id, string descripcion)
        {
            Rubro usuarioModificar = new Rubro()
            {
                Id = id,
                Descripcion = descripcion
            };
            return RubroDAO.Modificar(usuarioModificar);
        }

        public void EliminarRubro(int id)
        {
            Rubro usuarioExistente = RubroDAO.Obtener(id);
            RubroDAO.Eliminar(usuarioExistente);
        }

        public List<Rubro> ListarRubros()
        {
            return RubroDAO.ListarTodos().ToList();
        }

        #endregion

        #region . Empresa .

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

        public Empresa CrearEmpresa(string email, string clave, string razonSocial, string numeroRuc, Rubro rubro)
        {
            Empresa usuarioCrear = new Empresa()
            {
                EmailContacto = email,
                Clave = clave,
                RazonSocial = razonSocial,
                NumeroRuc = numeroRuc,
                Rubro = rubro
            };
            return EmpresaDAO.Crear(usuarioCrear);
        }

        public Empresa ObtenerEmpresa(int id)
        {
            return EmpresaDAO.Obtener(id);
        }

        public Empresa ModificarEmpresa(int id, string email, string clave, string razonSocial, string numeroRuc, Rubro rubro)
        {
            Empresa usuarioModificar = new Empresa()
            {
                Id = id,
                EmailContacto = email,
                Clave = clave,
                RazonSocial = razonSocial,
                NumeroRuc = numeroRuc,
                Rubro = rubro
            };
            return EmpresaDAO.Modificar(usuarioModificar);
        }

        public void EliminarEmpresa(int id)
        {
            Empresa usuarioExistente = EmpresaDAO.Obtener(id);
            EmpresaDAO.Eliminar(usuarioExistente);
        }

        public List<Empresa> ListarEmpresas()
        {
            return EmpresaDAO.ListarTodos().ToList();
        }

        #endregion
    }
}
