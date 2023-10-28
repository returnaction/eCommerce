using AutoMapper;
using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{userid}")]
        public IActionResult GetUserById(string userId)
        {
            try
            {
                var user = _context.Users
                    .Include(prImage => prImage.ProfileImages)
                    .FirstOrDefault(u => u.Id == userId);

                if (user is null)
                    return NotFound();

                var userDto = _mapper.Map<UserForDisplayDto>(user);

                return StatusCode(200, userDto);
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        
        
    }
}
