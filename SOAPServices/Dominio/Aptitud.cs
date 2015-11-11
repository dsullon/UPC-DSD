using System.Runtime.Serialization;

namespace SOAPServices.Dominio
{
    [DataContract]
    public class Empresa
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public int Valor { get; set; }


    }
}