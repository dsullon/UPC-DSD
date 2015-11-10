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
    }
}
