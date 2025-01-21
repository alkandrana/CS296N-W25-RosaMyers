using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace OnTolkien.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime SignUpDate { get; set; }
        
        [NotMapped]
        public IList<string>? RoleNames { get; set; }
    }
}
