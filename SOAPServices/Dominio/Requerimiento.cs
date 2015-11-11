using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SOAPServices.Dominio
{
     [DataContract]
    public class Requerimiento
    {
        [DataMember]
         public int Id { get; set; }

        [DataMember]
        public string titulo { get; set; }

        [DataMember]
        public string descripcion { get; set; }

    }
}