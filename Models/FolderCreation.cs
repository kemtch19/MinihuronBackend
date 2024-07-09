using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinihuronBackend.Models
{
    public class FolderCreation
    {
        public string? Name { get; set; }
        public int? parentFolderId { get; set;}
        public int? userId { get; set; }
    }
}