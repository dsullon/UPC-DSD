using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SOAPServices.Dominio
{
    [DataContract]
    public class Aptitud
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El campo descripcion es obligatorio")]
        public string Descripcion { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El campo valor es obligatorio")]
        public int Valor { get; set; }


    }
}