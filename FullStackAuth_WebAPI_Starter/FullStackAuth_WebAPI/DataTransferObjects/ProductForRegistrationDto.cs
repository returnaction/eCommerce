using FullStackAuth_WebAPI.Models;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class ProductForRegistrationDto
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductAmount { get; set; }
        public double ProductPrice { get; set; }



        public List<ProductImageForDisplayDto> ProductImages { get; set; }
    }
}
