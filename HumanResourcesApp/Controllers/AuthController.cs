using HumanResourcesApp.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HumanResourcesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // Simulăm o listă de utilizatori. Aceasta poate fi înlocuită cu o bază de date.
        private readonly List<User> _users = new List<User>
        {
            new User { Id = 1, Username = "admin", Password = "password" },
            new User { Id = 2, Username = "user", Password = "1234" }
        };

        private readonly ILogger<AuthController> _logger;

        // Constructor pentru injectarea logger-ului
        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Endpoint pentru logarea utilizatorului.
        /// </summary>
        /// <param name="user">Obiectul User care conține username și password</param>
        /// <returns>Un mesaj de succes sau eroare.</returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            if (user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                _logger.LogWarning("Request body invalid. Username sau Password este gol.");
                return BadRequest(new { message = "Username și Password sunt obligatorii." });
            }

            _logger.LogInformation($"Login attempt: Username={user.Username}");

            // Găsim utilizatorul în lista locală
            var existingUser = _users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

            if (existingUser == null)
            {
                _logger.LogWarning($"Invalid credentials for Username={user.Username}");
                return Unauthorized(new { message = "Invalid credentials" });
            }

            // Generăm un token fals (exemplu)
            var token = Guid.NewGuid().ToString();

            _logger.LogInformation($"Login successful for Username={user.Username}");
            return Ok(new { message = "Login successful", token });
        }
    }
}
