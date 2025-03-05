using ManheimWebApi.DTOs;
using ManheimWebApi.Models;
using ManheimWebApi.Repositories.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManheimWebApi.Controllers
{
    [Route("user")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("all")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return Ok(users);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            return Ok(user);
        }

        [Route("GetUserByEmail")]
        [HttpPost]
        public async Task<IActionResult> GetUserByEmail([FromBody] GetUserByEmaiRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                return BadRequest("Email is required.");
            }
            var user = await _userRepository.GetUserByEmailAsync(request.Email);

            if(user == null)
            {
                return NotFound($"User with email '{request.Email}' not found.");
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            // Check if email already exists
            var existingUser = await _userRepository.GetUserByEmailAsync(request.Email);
            if (existingUser != null)
            {
                return Conflict(new { message = "Email already exists!" });
            }

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Role = request.Role,
                Mobile = request.Mobile,
                Password = request.Password 
            };

            await _userRepository.CreateUserAsync(user);

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, new
            {
                message = "User created successfully",
                userId = user.Id
            });
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Returns validation errors
            }

            var existingUser = await _userRepository.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound(new { message = "User not found" });
            }

            // Update only the fields that are provided in the request
            if (!string.IsNullOrEmpty(request.Name))
                existingUser.Name = request.Name;

            if (!string.IsNullOrEmpty(request.Email))
                existingUser.Email = request.Email;

            if (request.Role.HasValue)
                existingUser.Role = request.Role.Value;

            if (request.Mobile.HasValue)
                existingUser.Mobile = request.Mobile.Value;

            await _userRepository.UpdateUserAsync(id, existingUser);

            return Ok(new { message = "User updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(id);

            if (existingUser == null)
            {
                return NotFound(new { message = "User not found" });
            }

            await _userRepository.DeleteUserAsync(id);

            return Ok(new { message = "User deleted successfully" });
        }




    }
}
