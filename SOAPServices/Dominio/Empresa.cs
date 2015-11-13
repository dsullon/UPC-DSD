using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SOAPServices.Dominio
{
    [DataContract]
    public class Empresa
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required(ErrorMessage="El campo Email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email ingresado no es válido")]
        public string EmailContacto { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El campo Clave es obligatorio")]
        public string Clave { get; set; }

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