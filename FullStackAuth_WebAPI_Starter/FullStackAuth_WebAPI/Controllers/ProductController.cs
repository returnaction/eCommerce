using AutoMapper;
using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;
using FullStackAuth_WebAPI.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Drawing.Imaging;
using System.Formats.Asn1;
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
                newProduct.IsAvailable = newProduct.ProductAmount > 0 && product.IsAvailableAfterRegistration ? true : false;
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
        [HttpPut("{productid}"), Authorize]
        public IActionResult UpdateProduct(string productId, [FromForm] ProductForRegistrationDto productToUpdate)
        {
            try
            {
                string userId = User.FindFirstValue("id");
                if (string.IsNullOrEmpty(userId))
                    return Unauthorized();

                var existProduct = _context.Products
                    .Include(purch => purch.Purchases)
                    .FirstOrDefault(p => p.ProductId == productId);

                if (existProduct is null)
                    return NotFound();

                if (existProduct.UserIdOfProduct != userId)
                    return Unauthorized();

                if (existProduct.Purchases.Count > 0)
                {
                    return StatusCode(304);
                }
                else
                {
                    existProduct.ProductName = productToUpdate.ProductName;
                    existProduct.ProductDescription = productToUpdate.ProductName;
                    existProduct.ProductAmount = productToUpdate.ProductAmount;
                    existProduct.IsAvailable = productToUpdate.IsAvailableAfterRegistration;
                    //TODO add images later
                    _context.SaveChanges();

                    var productDto = _mapper.Map<ProductForDisplayDto>(existProduct);
                    return StatusCode(204, productDto);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("purchase/{productid}/amount/{amount}"), Authorize]
        public IActionResult BuyProduct(string productId, int amount)
        {
            try
            {
                string userId = User.FindFirstValue("id");
                if (string.IsNullOrEmpty(userId))
                    return Unauthorized();

                var product = _context.Products
                    .Include(purchase => purchase.Purchases)
                    .FirstOrDefault(p => p.ProductId == productId);
                if (product is null)
                    return NotFound();

                if(product.ProductAmount < amount)
                {
                    return Ok("Not enough items");
                }

                product.ProductAmount -= amount;

                var newPurchase = new Purchase()
                {
                    StatusOfPurchase = PurchaseStatus.Open,
                    OpenDate = DateTime.Now,

                    BuyerUserId = userId,
                    SellerUserId = product.UserIdOfProduct
                };
                product.Purchases.Add(newPurchase);

                _context.SaveChanges();

                var newPurchaseDto = _mapper.Map<PurchaseForDisplayDto>(newPurchase);

                return StatusCode(201, newPurchaseDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("purchase/{purchaseId}/send"), Authorize]
        public IActionResult SendProduct(string purchaseId)
        {
            try
            {
                string userId = User.FindFirstValue("id");
                if (string.IsNullOrEmpty(userId))
                    return Unauthorized();

                var purchase = _context.Purchases.FirstOrDefault(p => p.PurchaseId == purchaseId);
                if (purchase is null)
                    return NotFound();

                if (purchase.SellerUserId != userId)
                    return BadRequest();

                if (purchase.StatusOfPurchase != PurchaseStatus.Open)
                    return BadRequest();

                purchase.StatusOfPurchase = PurchaseStatus.Send;
                purchase.SendDate = DateTime.Now;

                _context.SaveChanges();

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("purchase/recieveproduct/{purchaseId}"), Authorize]
        public IActionResult ReceiveProduct(string purchaseId)
        {
            try
            {
                string userId = User.FindFirstValue("id");
                if (string.IsNullOrEmpty(userId))
                    return Unauthorized();

                var purchase = _context.Purchases.FirstOrDefault(p => p.PurchaseId == purchaseId);
                if (purchase is null)
                    return NotFound();

                if (purchase.BuyerUserId != userId)
                    return BadRequest();

                if (purchase.StatusOfPurchase != PurchaseStatus.Send)
                    return BadRequest();

                purchase.StatusOfPurchase = PurchaseStatus.Recieved;
                purchase.RecieveDate = DateTime.Now;

                _context.SaveChanges();

                return StatusCode(201);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("purchase/clodepurchase/{purchaseId}"), Authorize]
        public IActionResult ClosePurchase(string purchaseId)
        {
            try
            {
                string userId = User.FindFirstValue("id");
                if (string.IsNullOrEmpty(userId))
                    return Unauthorized();

                var purchase = _context.Purchases.FirstOrDefault(p => p.PurchaseId == purchaseId);
                if (purchase is null)
                    return NotFound();

                if (purchase.BuyerUserId != userId)
                    return BadRequest();

                if (purchase.StatusOfPurchase != PurchaseStatus.Recieved)
                    return BadRequest();

                purchase.StatusOfPurchase = PurchaseStatus.Closed;
                purchase.CloseDate = DateTime.Now;

                _context.SaveChanges();

                return StatusCode(201);

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

        private PurchaseStatus GetPreviousPurchaseStatus(PurchaseStatus purchaseStatus)
        {
            switch(purchaseStatus)
            {
                case PurchaseStatus.Send:
                    return PurchaseStatus.Open;
                case PurchaseStatus.Recieved:
                    return PurchaseStatus.Send;
                case PurchaseStatus.Closed:
                    return PurchaseStatus.Recieved;
                default:
                    return PurchaseStatus.None;
            }
        }
    }
}
