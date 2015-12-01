using System.Runtime.Serialization;

namespace Reclutamiento.MVC.Models
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
