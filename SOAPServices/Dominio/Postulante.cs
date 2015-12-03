using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace SOAPServices.Dominio
{
    [DataContract]
    public class Postulante : Usuario
    {
        [DataMember]
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Nombre { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El campo Apellido Paterno es obligatorio")]
        public string ApellidoPaterno { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El campo Apellido Materno es obligatorio")]
        public string ApellidoMaterno { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El campo Fecha de Nacimiento es obligatorio")]
        public DateTime FechaNacimiento { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El campo DNI es obligatorio")]
        [EmailAddress(ErrorMessage = "El dni ingresado no es válido")]
        public string Dni { get; set; }

        [DataMember]
        public ICollection<Aptitud> Aptitudes { get; set; }
    }
}