using InternetSpeedTest.Infrastructure.Abstract;
using InternetSpeedTest.Infrastructure.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InternetSpeedTest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository context)
        {
            _userRepository = context;
        }
        [HttpPost]
        public async Task<IActionResult> PostUser(User user)
        {
            await _userRepository.CreateUserAsync(user);
            return NoContent();
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetUsersAsync();
        }
    }
}