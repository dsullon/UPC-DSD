using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reclutamiento.MVC.Models
{
    public class RegistrarEmpresa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Número de RUC es obligatorio")]
        [Display(Name = "Número R.U.C.:")]
        public string NumeroRuc { get; set; }

        [Required(ErrorMessage = "El campo Razón Social es obligatorio")]
        [Display(Name = "Razón social:")]
        public string RazonSocial { get; set; }

        [Required(ErrorMessage = "El campo Email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email ingresado no es válido")]
        [Display(Name = "Email:")]
        public string EmailContacto { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es obligatorio")]
        [Display(Name = "Contraseña:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña:")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmarPassword { get; set; }

        public int? RubroID { get; set; }

        public System.Web.Mvc.SelectList Rubros { get; set; }

    }
}