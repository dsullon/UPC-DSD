using System.Runtime.Serialization;

namespace SOAPServices.Dominio
{
    [DataContract]
    public class Empresa
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string EmailContacto { get; set; }

        [DataMember]
        public string Clave { get; set; }

        [DataMember]
        public string RazonSocial { get; set; }

        [DataMember]
        public string NumeroRuc { get; set; }

        [DataMember]
        public Rubro Rubro { get; set; }
    }
}