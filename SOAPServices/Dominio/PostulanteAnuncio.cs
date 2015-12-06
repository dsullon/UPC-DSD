using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SOAPServices.Dominio
{
    [DataContract]
    public class PostulanteAnuncio
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Postulante Postulante { get; set; }

        [DataMember]
        public Anuncio Anuncio { get; set; }
    }
}