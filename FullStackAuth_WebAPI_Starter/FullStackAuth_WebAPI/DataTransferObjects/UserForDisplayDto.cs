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
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }

        public List<ProfileImageforDisplayDto> ProfileImages { get; set; }
        public List<ProductForDisplayDto> Products { get; set; }
        public List<PurchaseForDisplayDto> PurchasesUserIsSeller { get; set; }
        public List<PurchaseForDisplayDto> PurchasesUserISBuyer { get; set; }
    }
}
