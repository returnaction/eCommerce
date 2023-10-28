using FullStackAuth_WebAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class ReviewImageForDisplayDto
    {
        public string ReviewImageId { get; set; }
        public DateTime ReviewImageDate { get; set; }
        public string ReviewImageSrc { get; set; }

        //Nav Props
        public string ReviewIdOfReviewImage { get; set; }
        public ReviewForDisplayDto ReviewOfReviewImage { get; set; }
    }
}
