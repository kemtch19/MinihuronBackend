using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MinihuronBackend.Models
{
    [Table("folders")]
    public class Folder
    {
        [Required]
        [Column("id_folder")]
        public int Id { get; set; }

        [Column("Name")]
        [Required(ErrorMessage = "Possible null Name of Folder")]
        public string? Name { get; set; }

        [Column("parentFolderId")]
        public int? parentFolderId { get; set; }


        [Required(ErrorMessage = "Possible null value")]
        public int? UserId{ get; set; }
        public User? User{ get; set; }

        [JsonIgnore]
        public Folder? ParentFolder { get; set; }
        [JsonIgnore]
        public ICollection<Folder>? subFolder { get; set; } = new List<Folder>();
        [JsonIgnore]
        public ICollection<Archive>? Files { get; set; } = new List<Archive>();
    }
}