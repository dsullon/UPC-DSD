using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SOAPServices.Dominio
{
    [DataContract]
    public class ErrorData
    {
        public ErrorData()
        { }

        public ErrorData(string motivo, string detalle)
        {
            Motivo = motivo;
            Detalle = detalle;
        }

        [DataMember]
        public string Motivo { get; private set; }

        [DataMember]
        public string Detalle { get; private set; }
    }
}