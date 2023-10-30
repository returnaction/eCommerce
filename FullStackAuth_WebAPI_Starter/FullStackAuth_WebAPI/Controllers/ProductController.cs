using AutoMapper;
using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Claims;

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllAvailableProducts()
        {
            try
            {
                var products = _context.Products.Where(p => p.IsAvailable == true && p.IsDeleted == false).ToList();

                var productsDto = _mapper.Map<List<ProductForDisplayDto>>(products);

                return StatusCode(200, productsDto);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("user/{userid}")]
        public IActionResult GetProductsByUserId(string userId)
        {
            try
            {
                List<Product> productofUser = _context.Products.Where(p => p.UserIdOfProduct == userId).ToList();

                var productOfUserDto = _mapper.Map<List<ProductForDisplayDto>>(productofUser);

                return StatusCode(200, productOfUserDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost, Authorize]
        public IActionResult RegisterProduct([FromForm] ProductForRegistrationDto product)
        {
            try
            {
                string userId = User.FindFirstValue("id");
                if (string.IsNullOrEmpty(userId))
                    return Unauthorized();

                var newProduct = _mapper.Map<Product>(product);
                newProduct.IsAvailable = newProduct.ProductAmount > 0 && product.IsAvailableAfterRegistration? true : false;
                newProduct.UserIdOfProduct = userId;
                newProduct.ProductRegistrationDate = DateTime.Now;
                newProduct.ProductImages = new List<ProductImage>();
                if (product.ProductImages != null)
                {
                    foreach (var productImage in product.ProductImages)
                    {
                        if (productImage.ProductImageFile != null)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                productImage.ProductImageFile.CopyTo(memoryStream);
                                using (var image = Image.FromStream(memoryStream, true))
                                {
                                    var newimage = new ProductImage()
                                    {
                                        ProductImageDate = DateTime.Now,
                                        ProductImageSrc = ImageBase64Encode(image)

                                    };
                                    newProduct.ProductImages.Add(newimage);
                                }
                            }
                        }
                    }
                }
                _context.Products.Add(newProduct);
                _context.SaveChanges();


                var newProductDto = _mapper.Map<ProductForDisplayDto>(newProduct);
                return StatusCode(201, newProductDto);


            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{productid}"), Authorize]
        public IActionResult DeleteProduct(string productId)
        {
            try
            {
                string userid = User.FindFirstValue("id");
                if (string.IsNullOrEmpty(userid))
                    return Unauthorized();

                var product = _context.Products
                    .Include(p => p.Purchases)
                    .FirstOrDefault(x => x.ProductId == productId);

                if (product == null)
                    return NotFound();
                if (product.UserIdOfProduct != userid)
                    return Unauthorized();
                if (product.Purchases.Count > 0)
                {
                    product.IsDeleted = true;
                    product.IsAvailable = false;
                }
                else
                    _context.Products.Remove(product);

                _context.SaveChanges();

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        private string ImageBase64Encode(Image img)
        {
            using (Image image = img)
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, ImageFormat.Jpeg);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }
    }
}
