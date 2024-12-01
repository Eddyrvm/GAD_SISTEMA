using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using System.Web;

namespace GAD_SISTEMA.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(50, ErrorMessage = "El rol no puede superar los 50 caracteres.")]
        public string Nombres { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(50, ErrorMessage = "El rol no puede superar los 50 caracteres.")]
        public string Apellidos { get; set; }

        [Display(Name = "Usuario")]
        public string UsuarioLogin
        {
            get
            {
                string primerNombre = Regex.Match(Nombres ?? string.Empty, @"^\w+").Value;
                string primerApellido = Regex.Match(Apellidos ?? string.Empty, @"^\w+").Value;
                return $"{primerNombre} {primerApellido}";
            }
        }

        [DataType(DataType.PhoneNumber)]
        [MaxLength(16, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre de usuario no puede superar los 50 caracteres.")]
        public string UserName { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(100, ErrorMessage = "La contraseña no puede superar los 100 caracteres.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "La contraseña no coincide.")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        public bool IsActive { get; set; } = true; // Indica si el usuario está activo.

        [Display(Name = "Usuario")]
        public String FullName { get { return string.Format("{0} {1}", Apellidos, Nombres); } }

        [DataType(DataType.ImageUrl)]
        public string Foto { get; set; }

        [NotMapped]
        public HttpPostedFileBase FotoFile { get; set; }
    }

}
