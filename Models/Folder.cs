using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MinihuronBackend.Models
{
    [Table("folders")]
    public class Folder
    {
        [Key]
        [Column("id_folder")]
        public int Id { get; set; }

        [Column("Name")]
        [Required(ErrorMessage = "Possible null Name of Folder")]
        public string? Name { get; set; }

        [Column("parentFolderId")]
        public int? parentFolderId { get; set; }
        
        [JsonIgnore]
        public Folder? parentFolder { get; set; }

        [Required(ErrorMessage = "Possible null value")]
        public int? UserId{ get; set; }
        public User? User{ get; set; }

        public ICollection<Folder> Subfolder { get; set; } = new List<Folder>();
        
        [JsonIgnore]
        public ICollection<Archive> Files { get; set; } = new List<Archive>();
    }   
}