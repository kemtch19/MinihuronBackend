using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinihuronBackend.Data;
using MinihuronBackend.DTO;
using MinihuronBackend.Models;

namespace MinihuronBackend.Controllers.Users
{
    [ApiController]
    [Route("/api/users/signup")]
    public class SignUpController : ControllerBase
    {
        private readonly MiniHuronContext _context;
        public SignUpController(MiniHuronContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Register([FromBody] Register registerRequest)
        {
            // verificamos que los datos proporcionados estén bien formados y no estén vacíos
            if (registerRequest == null || string.IsNullOrWhiteSpace(registerRequest.Name) || string.IsNullOrWhiteSpace(registerRequest.Email) || string.IsNullOrWhiteSpace(registerRequest.Password) || string.IsNullOrWhiteSpace(registerRequest.Phone))
            {
                return BadRequest("Datos invalidos");
            }

            // vamos a verificar si el usuario ya existe en la base de datos
            if (_context.Users.Any(u => u.Email == registerRequest.Email))
            {
                return BadRequest("El correo electrónico ya está en uso.");
            }

            // creamos el nuevo usuario
            var user = new User
            {
                Name = registerRequest.Name,
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                Phone = registerRequest.Phone
            };

            // agregamos el nuevo usuario al contexto
            _context.Users.Add(user);
            // guardamos los cambios en la base de datos
            _context.SaveChanges();

            return Ok($"Bienvenido {registerRequest.Name}!!, Su registro fue enviado exitosamente. Diviertete :3");
        }
    }
}