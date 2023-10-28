using FullStackAuth_WebAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class ProfileImageforDisplayDto
    {
        public string ProfileImageId { get; set; }

        public DateTime ProdileImageDate { get; set; }
        public string ProfileImageSrc { get; set; }

        public string UserIdOfProfileImage { get; set; }
        public UserForDisplayDto UserOfProfileImage { get; set; }
    }
}
