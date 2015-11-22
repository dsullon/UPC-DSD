using SOAPServices.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SOAPServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IEntityServices" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IEntityServices
    {
        #region . EMPRESA .

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Empresas", ResponseFormat = WebMessageFormat.Json)]
        List<Empresa> ListarEmpresa();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Empresas/{id}", ResponseFormat = WebMessageFormat.Json)]
        Empresa ObtenerEmpresa(string id);

        #endregion
    }
}
