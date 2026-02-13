using Habits.Domain.Users;
using Microsoft.AspNetCore.Mvc;

namespace Habits.Host.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UserController(IUserService _service) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            await _service.CreateUser(user);
            return Ok();
        }
    }
}
