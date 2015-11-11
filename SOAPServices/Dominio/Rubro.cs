using System.Runtime.Serialization;

namespace SOAPServices.Dominio
{
    [DataContract]
    public class Rubro
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Descripcion { get; set; }
    }
}
