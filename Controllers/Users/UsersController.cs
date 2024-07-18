using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinihuronBackend.Data;
using MinihuronBackend.Models;

namespace MinihuronBackend.Controllers.Users
{
    [ApiController]
    [Route("/api/users")]
    public class UsersController: ControllerBase
    {
        private readonly MiniHuronContext _context;
        public UsersController(MiniHuronContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            List<User> users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("users/{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
    }
}