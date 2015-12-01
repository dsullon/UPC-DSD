using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reclutamiento.MVC.Models
{
    public static class Generico
    {
        private static string _urlServicioRest = "http://localhost:40845/EntityServices.svc/";

        public static string UrlServicioRest
        {
            get { return _urlServicioRest; }
        }

    }
}