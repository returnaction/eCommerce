using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.Models
{
    public class Review
    {
        public Review()
        {
            ReviewId = Guid.NewGuid().ToString();
        }

        [Key]
        public string ReviewId { get; set; }

        [MaxLength(500)]
        [MinLength(5)]
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }
        public double ReviewRaiting { get; set; }

        //Nav Prop

        [ForeignKey("User")]
        public string UserIdOfReview { get; set; }
        public User UserOfReview { get; set; }

        public List<ReviewImage> ReviewImages { get; set; }

        [ForeignKey("Purchase")]
        public string PurchaseIdOfProductReview { get; set; }
        public Purchase PurchaseOfProductReview { get; set; }

    }
}
