using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SOAPServices.Dominio
{
    [DataContract]
    public class Anuncio
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El campo titulo es obligatorio")]
        public string titulo { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El campo descripcion es obligatorio")]
        public string descripcion { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El campo aptitud es obligatorio")]
        public Aptitud aptitud { get; set; }
    }
}