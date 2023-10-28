using FullStackAuth_WebAPI.Models.Enums;
using FullStackAuth_WebAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class PurchaseForDisplayDto
    {
        public string PurchaseId { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime AwaitingDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public PurchaseStatus StatusOfPurchase { get; set; }

        //Nav Props
        public string ProductIdOfPurchase { get; set; }
        public ProductForDisplayDto ProductOfPurchase { get; set; }

        public string ReviewIdOfPurchase { get; set; }
        public ReviewForDisplayDto ReviewOfPurchase { get; set; }

        public string BuyerUserId { get; set; }
        public UserForDisplayDto BuyerUser { get; set; }
        public string SellerUserId { get; set; }
        public UserForDisplayDto SellerUser { get; set; }
    }
}
