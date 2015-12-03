using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SOAPServices.Dominio
{
    [DataContract]
    public class Empresa : Usuario
    {
        [DataMember]
        [Required(ErrorMessage = "El campo Razón Social es obligatorio")]
        public string RazonSocial { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El campo Número de RUC es obligatorio")]
        public string NumeroRuc { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El campo Rubro es obligatorio")]
        public Rubro Rubro { get; set; }
    }
}