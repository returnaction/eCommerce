using FullStackAuth_WebAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class ReviewForDisplayDto
    {
        public string ReviewId { get; set; }

        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }
        public double ReviewRaiting { get; set; }

        //Nav Prop
        public string UserIdOfReview { get; set; }
        public UserForDisplayDto UserOfReview { get; set; }

        public string ProductIdOfReview { get; set; }
        public ProductForDisplayDto ProductOfReview { get; set; }

        public List<ReviewImageForDisplayDto> ReviewImages { get; set; }

        public string PurchaseIdOfProductReview { get; set; }
        public PurchaseForDisplayDto PurchaseOfProductReview { get; set; }
    }
}
