using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MinihuronBackend.Models
{
    public class Folder
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Possible null Name of Folder")]
        public string? Name { get; set; }


        public string? parentFolderId { get; set; }


        [Required(ErrorMessage = "Possible null value")]
        public int? UserId{ get; set; }
        public User? User{ get; set; }

        [JsonIgnore]
        public Folder? parentFolder { get; set; }
        public ICollection<Folder>? subFolder { get; set; } = new List<Folder>();
        public ICollection<Archive>? Files { get; set; } = new List<Archive>();
    }
}