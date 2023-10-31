using FullStackAuth_WebAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace FullStackAuth_WebAPI.Models
{
    public class Purchase
    {
        public Purchase()
        {
            PurchaseId = Guid.NewGuid().ToString();
        }

        [Key]
        public string PurchaseId { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime RecieveDate { get; set; }
        public DateTime CloseDate { get; set; }
        public PurchaseStatus StatusOfPurchase { get; set; }

        //Nav Props
        [ForeignKey("Product")]
        public string ProductIdOfPurchase { get; set; }
        public Product ProductOfPurchase { get; set; }

        [ForeignKey("Review")]
        public string ReviewIdOfPurchase { get; set; }
        public Review ReviewOfPurchase { get; set; }

        [ForeignKey("BuyerUserId")]
        public string BuyerUserId { get; set; }
        public User BuyerUser { get; set; }

        [ForeignKey("SellerUserId")]
        public string SellerUserId { get; set; }
        public User SellerUser { get; set; }

    }
}
