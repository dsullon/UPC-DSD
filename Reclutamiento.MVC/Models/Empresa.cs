using Reclutamiento.MVC.ReclutamientoWS;

namespace Reclutamiento.MVC.Models
{
    public class Empresa: Usuario
    {
        public string RazonSocial { get; set; }

        public string NumeroRuc { get; set; }

        public Rubro Rubro { get; set; }
    }
}