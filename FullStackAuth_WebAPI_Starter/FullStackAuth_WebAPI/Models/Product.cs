using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.Models
{
    public class Product
    {
        public Product()
        {
            ProductId = Guid.NewGuid().ToString();
        }

        [Key]
        public string ProductId { get; set; }

        [MaxLength(30)]
        [MinLength(1)]
        public string ProductName { get; set; }

        [MaxLength(500)]
        [MinLength(5)]
        public string ProductDescription { get; set; }
        public bool ProductIsAvailable { get; set; }
        public int ProductAmount { get; set; }
        public double ProductPrice { get; set; }
        public double ProductRaiting { get; set; }

        //Nav Props

        [ForeignKey("User")]
        public string UserIdOfProduct { get; set; }
        public User UserOfProduct { get; set; }

        public List<ProductImage> ProductImages { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Purchase> Purchases { get; set; }

    }
}
