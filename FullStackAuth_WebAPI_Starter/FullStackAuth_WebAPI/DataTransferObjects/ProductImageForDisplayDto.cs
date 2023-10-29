using FullStackAuth_WebAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class ProductImageForDisplayDto
    {
        public string ProductImageId { get; set; }
        public DateTime ProductImageDate { get; set; }
        public string ProductImageSrc { get; set; }

        public string ProductIdOfImage { get; set; }
        public ProductForDisplayDto ProductOfImage { get; set; }

        public IFormFile ProductImageFile { get; set; }

    }
}
