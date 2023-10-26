using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.Models
{
    public class User : IdentityUser
    {
        [MaxLength(30)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime DateOfBirth { get; set; }

        //Nav Props
        public List<ProfileImage> ProfileImages { get; set; }
        public List<Product> Products { get; set; }


    }
}
