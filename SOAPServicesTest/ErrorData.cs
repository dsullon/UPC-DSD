using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAPServicesTest
{
    public class ErrorData
    {
        public ErrorData()
        { }

        public ErrorData(string motivo, string detalle)
        {
            Motivo = motivo;
            Detalle = detalle;
        }

        public string Motivo { get; private set; }

        public string Detalle { get; private set; }
    }
}
