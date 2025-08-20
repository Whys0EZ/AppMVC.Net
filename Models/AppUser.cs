using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AppMVC.Net.Models
{
    public class AppUser : IdentityUser
    {
        [Column(TypeName = "nvarchar(400)")]
        public string? HomeAddress { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        
    }
}