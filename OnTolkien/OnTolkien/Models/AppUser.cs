using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OnTolkien.Models
{
    public class AppUser
    {
        public int AppUserId { get; set; }
        
        public string UserName { get; set; }

        public DateTime SignUpDate { get; set; }
    }
}
