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

        public Empresa CrearEmpresa(Empresa empresa)
        {
            return EmpresaDAO.Crear(empresa);
        }

        public bool EliminarEmpresa(Empresa empresa)
        {
            int idEmpresa = empresa.Id;
            EmpresaDAO.Eliminar(empresa);
            var emp = EmpresaDAO.Obtener(idEmpresa);
            return emp == null;
        }

        public Empresa ModificarEmpresa(Empresa empresa)
        {
            return EmpresaDAO.Modificar(empresa);
        }

        public List<Empresa> ListarEmpresa()
        {
            return EmpresaDAO.ListarTodos().ToList();
        }

        public Empresa ObtenerEmpresa(string id)
        {
            int idEmpresa = int.Parse(id);
            return EmpresaDAO.Obtener(idEmpresa);
        }

        #endregion


    }
}
