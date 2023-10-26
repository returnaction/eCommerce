using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.Models
{
    public class ProductImage
    {
        public ProductImage()
        {
            ProductImageId = Guid.NewGuid().ToString();
        }

        [Key]
        public string ProductImageId { get; set; }
        public DateTime ProductImageDate { get; set; }
        public string ProductImageSrc { get; set; }


        [ForeignKey("Product")]
        public string ProductIdOfImage { get; set; }
        public Product ProductOfImage { get; set; }

    }
}
