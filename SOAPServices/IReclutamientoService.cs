using SOAPServices.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOAPServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IReclutamientoService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IReclutamientoService
    {
        #region . Rubro .

        [OperationContract]
        Rubro CrearRubro(string descripcion);
        [OperationContract]
        Rubro ObtenerRubro(int id);
        [OperationContract]
        Rubro ModificarRubro(int id, string descripcion);
        [OperationContract]
        void EliminarRubro(int id);
        [OperationContract]
        List<Rubro> ListarRubros();

        #endregion

        #region . Empresa .

        [OperationContract]
        Empresa CrearEmpresa(string email, string clave, string razonSocial, string numeroRuc, Rubro rubro);
        [OperationContract]
        Empresa ObtenerEmpresa(int id);
        [OperationContract]
        Empresa ModificarEmpresa(int id, string email, string clave, string razonSocial, string numeroRuc, Rubro rubro);
        [OperationContract]
        void EliminarEmpresa(int id);
        [OperationContract]
        List<Empresa> ListarEmpresas();

        #endregion
    }
}
