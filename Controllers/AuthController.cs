using System.Threading.Tasks;
using DatingApp.api.Data;
using DatingApp.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.api.Controllers
{
    [Route("api/{controller}")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            // validate request

            username = username.ToLower();
            if (await _repo.UserExistsAsync(username)) return BadRequest("Username is already taken.");
            var userToCreate = new User
            {
                Username = username
            };
            var createUser = await _repo.Register(userToCreate, password);
            return StatusCode(201);
        }
    }
}