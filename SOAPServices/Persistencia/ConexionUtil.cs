using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAPServices.Persistencia
{
    public class ConexionUtil
    {
        public static string ObtenerCadena()
        {
            return "Database=Reclutamiento;Data Source=localhost;User Id=root;Password=";
            //return "Database=Reclutamiento;Data Source=br-cdbr-azure-south-a.cloudapp.net;User Id=b904472183830c;Password=8cfea840";
        }
    }
}
