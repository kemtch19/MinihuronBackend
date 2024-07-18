using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinihuronBackend.Data;
using MinihuronBackend.Models;

namespace MinihuronBackend.Controllers.Folders
{
    [ApiController]
    [Route("/api/Folders/create")]
    [Authorize]
    public class FolderCreateController : ControllerBase
    {
        private readonly MiniHuronContext _context;
        public FolderCreateController(MiniHuronContext context)
        {
            _context = context;
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
                parentFolder = await _context.folders.FindAsync(model.parentFolderId.Value);
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

            _context.folders.Add(folder);
            await _context.SaveChangesAsync();
            return Ok(folder);
        }
    }
}