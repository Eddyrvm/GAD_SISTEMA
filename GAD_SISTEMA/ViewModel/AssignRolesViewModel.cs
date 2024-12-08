using GAD_SISTEMA.Models;
using System.Collections.Generic;

namespace GAD_SISTEMA.ViewModel
{
    public class AssignRolesViewModel
    {
        public int UserId { get; set; }
        public List<Role> AvailableRoles { get; set; }
        public List<int> AssignedRoles { get; set; }
    }

}