using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SOAPServices.Dominio
{
    [DataContract]
    public class Postulante
    {
        [DataMember]
        public int idPostulante { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string apellidoPaterno { get; set; }

        [DataMember]
        public string apellidoMaterno { get; set; }

        [DataMember]
        public string fechaNacimiento { get; set; }

        [DataMember]
        public string email { get; set; }

        [DataMember]
        public string clave { get; set; }
    }
}