using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Reclutamiento.MVC.Models
{
    [DataContract]
    public class Aptitud_Anuncio
    {
        [DataMember]
        public int IdAnuncio { get; set; }

        [DataMember]
        public int IdAptitud { get; set; }
    }
}