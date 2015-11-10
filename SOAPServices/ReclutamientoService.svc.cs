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
    }
}
