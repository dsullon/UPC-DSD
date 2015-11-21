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
        OperationStatus CrearEmpresa(string email, string clave, string razonSocial, string numeroRuc, int idRubro);
        [OperationContract]
        Empresa ObtenerEmpresa(int id);
        [OperationContract]
        Empresa ModificarEmpresa(int id, string email, string clave, string razonSocial, string numeroRuc, int idRubro);
        [OperationContract]
        void EliminarEmpresa(int id);
        [OperationContract]
        List<Empresa> ListarEmpresas();

        #endregion

        #region . Postulante .

        [OperationContract]
        OperationStatus CrearPostulante(string nombre, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, string email, string dni, string clave);
        [OperationContract]
        Postulante ObtenerPostulante(int id);
        [OperationContract]
        Postulante ModificarPostulante(int idPostulante, string nombre, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, string email, string dni, string clave);
        [OperationContract]
        void EliminarPostulante(int id);
        [OperationContract]
        List<Postulante> ListarPostulante();

        #endregion

        //#region . Anuncio .

        //[OperationContract]
        //OperationStatus CrearAnuncio(string titulo, string descripcion, int idAptitud);
        //[OperationContract]
        //Empresa ObtenerAnuncio(int id);
        //[OperationContract]
        //Empresa ModificarAnuncio(int id, string titulo, string descripcion, int idAptitud);
        //[OperationContract]
        //void EliminarAnuncio(int id);
        //[OperationContract]
        //List<Anuncio> ListarAnuncios();

        //#endregion

        //#region . Aptitud .

        //[OperationContract]
        //Rubro CrearAptitud(string descripcion, int valor);
        //[OperationContract]
        //Rubro ObtenerAptitud(int id);
        //[OperationContract]
        //Rubro ModificarAptitud(int id, string descripcion, int valor);
        //[OperationContract]
        //void EliminarAptitud(int id);
        //[OperationContract]
        //List<Aptitud> ListarAptitudes();

        //#endregion
    }
}
