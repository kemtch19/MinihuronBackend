using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinihuronBackend.Data;
using MinihuronBackend.Models;

namespace MinihuronBackend.Controllers.Folders
{
    [ApiController]
    [Route("/api/Folders")]
    public class FoldersController : ControllerBase
    {
        private readonly MiniHuronContext _context;
        public FoldersController(MiniHuronContext context)
        {
            _context = context;
        }
        [HttpGet("Folders")]
        public async Task<IActionResult> GetFolders()
        {
            List<Folder> folders = await _context.folders.Include(f => f.User).ToListAsync();
            Console.WriteLine(folders[0]);
            return Ok(folders);
        }
    }
}