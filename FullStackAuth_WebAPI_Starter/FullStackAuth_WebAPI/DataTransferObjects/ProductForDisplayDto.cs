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

        public UserForDisplayDto UserOfProduct { get; set; }

        public List<ProductImageForDisplayDto> ProductImages { get; set; }
        public List<ReviewForDisplayDto> Reviews { get; set; }
    }
}
