using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace AuthProject.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public string RollName { get; set; }
        
    }
}
