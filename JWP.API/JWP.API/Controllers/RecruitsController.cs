using JWP.API.Models;
using JWP.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWP.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitsController : ControllerBase
    {
        private readonly ITokenRepository _tokenRepository;
        public RecruitsController(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        // GET: api/<RecruitsController>
        [HttpGet]
        public List<string> Get()
        {
            return new List<string>
            {
                "John Doe",
                "Jane Doe",
                "Juniot Doe"
            };
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(Users usersData)
        {
            var token = _tokenRepository.Authenticate(usersData);
            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
    }
}
