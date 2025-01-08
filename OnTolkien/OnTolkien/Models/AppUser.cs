using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace OnTolkien.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime SignUpDate { get; set; }
    }
}
