using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinihuronBackend.Data;
using MinihuronBackend.Models;

namespace MinihuronBackend.Controllers.Files
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize]
    public class FilesController : ControllerBase
    {
        private readonly MiniHuronContext _context;
        public FilesController(MiniHuronContext context)
        {
            _context = context;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file, int folderId)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file provided");

            var folder = await _context.folders.FindAsync(folderId);

            if (folder == null)
            {
                return NotFound("Folder not found");
            }

            var filePath = Path.Combine("Files", file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var archive = new Models.Archive
            {
                Name = file.FileName,
                FilePath = filePath,
                FolderId = folderId
            };

            _context.Files.Add(archive);
            await _context.SaveChangesAsync();

            return Ok(new { message = "File uploaded successfully.", filePath });
        }

        
    }
}