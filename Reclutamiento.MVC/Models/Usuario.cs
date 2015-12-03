
namespace Reclutamiento.MVC.Models
{
    public abstract class Usuario
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Clave { get; set; }
    }
}