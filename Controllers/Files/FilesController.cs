using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinihuronBackend.Data;
using MinihuronBackend.Models;

namespace MinihuronBackend.Controllers.Files
{
    [ApiController]
    [Route("/api/[controller]")]
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

            var folder = await _context.Folders.FindAsync(folderId);

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

        [HttpPost("create-folder")]
        public async Task<IActionResult> CreateFolder([FromBody] FolderCreation model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Folder parentFolder = null;

            if (model.parentFolderId.HasValue)
            {
                parentFolder = await _context.Folders.FindAsync(model.parentFolderId.Value);
                if (parentFolder == null)
                {
                    return NotFound("Parent folder not found");
                }
            }

            var folder = new Folder
            {
                Name = model.Name,
                parentFolderId = model.parentFolderId,
                UserId = model.userId
            };

            _context.Folders.Add(folder);
            await _context.SaveChangesAsync();
            return Ok(folder);
        }

        [HttpGet("folders")]
        public async Task<IActionResult> GetFolders(int userId)
        {
            var folders = await _context.Folders.Where(f => f.UserId == userId).ToListAsync();
            return Ok(folders);
        }
    }
}