using Microsoft.AspNetCore.Mvc;
using MinihuronBackend.Data;
using MinihuronBackend.DTO;

namespace MinihuronBackend.Controllers.Users
{
    [ApiController]
    [Route("/api/users/signin")]
    public class SignInController : ControllerBase
    {
        private readonly MiniHuronContext _context;
        public SignInController(MiniHuronContext context)
        {
            _context = context;
        }

        public IActionResult SignInMethod([FromBody] AuthResponse authResponse)
        {
            if (authResponse == null || string.IsNullOrEmpty(authResponse.Email) || string.IsNullOrEmpty(authResponse.Password))
            {
                return BadRequest("Datos no validos, verifica");
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == authResponse.Email && u.Password == authResponse.Password);

            if (user == null)
            {
                return Unauthorized("Credenciales incorrectas");
            }
            else
            {
                return Ok($"Bienvenido {user.Name}");
            }
        }
    }
}