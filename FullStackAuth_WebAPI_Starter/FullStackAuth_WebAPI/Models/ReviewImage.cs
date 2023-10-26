using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.Models
{
    public class ReviewImage
    {
        public ReviewImage()
        {
            ReviewImageId = Guid.NewGuid().ToString();
        }
        [Key]
        public string ReviewImageId { get; set; }
        public DateTime ReviewImageDate { get; set; }
        public string ReviewImageSrc { get; set; }

        //Nav Props
        [ForeignKey("Review")]
        public string ReviewIdOfReviewImage { get; set; }
        public Review ReviewOfReviewImage { get; set; }

    }
}
