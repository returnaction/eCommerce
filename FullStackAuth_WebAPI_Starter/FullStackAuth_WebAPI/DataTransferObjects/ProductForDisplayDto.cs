using FullStackAuth_WebAPI.Models;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class ProductForDisplayDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public bool ProductIsAvailable { get; set; }
        public int ProductAmount { get; set; }
        public double ProductPrice { get; set; }
        public double ProductRaiting { get; set; }

        public User UserOfProduct { get; set; }

        public List<ProductImage> ProductImages { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
