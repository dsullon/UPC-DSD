using Reclutamiento.MVC.ReclutamientoWS;
using System;
using System.Collections.Generic;

namespace Reclutamiento.MVC.Models
{
    public class Postulante: Usuario
    {
        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Dni { get; set; }

        public ICollection<Aptitud> Aptitudes { get; set; }
    }
}