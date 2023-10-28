using AutoMapper;
using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("user/{userid}")]
        public IActionResult GetProductsByUserId(string userId)
        {
            try
            {
                List<Product> productofUser = _context.Products.Where(p => p.UserIdOfProduct == userId).ToList();

                var productDto = _mapper.Map<>
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
