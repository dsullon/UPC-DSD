using System;
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

    public class RegistrarPostulante
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Número de DNI es obligatorio")]
        [Display(Name = "Número D.N.I.:")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [Display(Name = "Nombre:")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo Apellido Pat. es obligatorio")]
        [Display(Name = "Apellido Pat.:")]
        public string ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "El campo Apellido Mat. es obligatorio")]
        [Display(Name = "Apellido Mat.:")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "El campo Fecha Nac. es obligatorio")]
        [Display(Name = "Fecha Nac.:")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

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

    }

    public class InicioSesionViewModel
    {
        [Required]
        [Display(Name = "Correo electrónico")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }
}