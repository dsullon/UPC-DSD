using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace SOAPServices.Dominio
{
    [DataContract]
    public class Postulante
    {
        [DataMember]        
        public int idPostulante { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string nombre { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El campo Apellido Paterno es obligatorio")]
        public string apellidoPaterno { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El campo Apellido Materno es obligatorio")]
        public string apellidoMaterno { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El campo Fecha de Nacimiento es obligatorio")]
        public DateTime fechaNacimiento { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El campo Email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email ingresado no es válido")]
        public string email { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El campo DNI es obligatorio")]
        [EmailAddress(ErrorMessage = "El dni ingresado no es válido")]
        public string dni { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El campo Clave es obligatorio")]
        public string clave { get; set; }
    }
}