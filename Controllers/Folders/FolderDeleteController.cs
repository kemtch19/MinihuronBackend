using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinihuronBackend.Data;

namespace MinihuronBackend.Controllers.Folders
{
    [ApiController]
    [Route("/api/Folders/delete")]
    [Authorize]
    public class FolderDeleteController : ControllerBase
    {
        private readonly MiniHuronContext _context;
        public FolderDeleteController(MiniHuronContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFolder(int id)
        {
            var folder = await _context.folders.FindAsync(id);
            System.Console.WriteLine(folder);
            if (folder == null)
            {
                return NotFound();
            }
            _context.folders.Remove(folder);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}