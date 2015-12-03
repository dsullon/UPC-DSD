using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SOAPServices.Dominio
{
     [DataContract]
    public abstract class Usuario
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El campo Email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email ingresado no es válido")]
        public string Email { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El campo Clave es obligatorio")]
        public string Clave { get; set; }
    }
}