using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.Models
{
    public class ProfileImage
    {
        public ProfileImage()
        {
            ProfileImageId = Guid.NewGuid().ToString();
        }
        [Key]
        public string ProfileImageId { get; set; }

        public DateTime ProdileImageDate { get; set; }
        public string ProfileImageSrc { get; set; }

        [ForeignKey("User")]
        public string UserIdOfProfileImage { get; set; }
        public User UserOfProfileImage { get; set; }


    }
}
