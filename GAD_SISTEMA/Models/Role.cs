using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GAD_SISTEMA.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "El nombre del rol es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre del rol no puede superar los 50 caracteres.")]
        public string RoleName { get; set; }

        // Relación con los usuarios.
        public virtual ICollection<User> Users { get; set; }
    }

}