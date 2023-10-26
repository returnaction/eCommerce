using FullStackAuth_WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class UserForDisplayDto
    {
        //DTO used when displaying User linked with FK
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }

        public List<ProfileImage> ProfileImages { get; set; }
        public List<Product> Products { get; set; }
        public List<Purchase> PurchasesUserIsSeller { get; set; }
        public List<Purchase> PurchasesUserISBuyer { get; set; }
    }
}
