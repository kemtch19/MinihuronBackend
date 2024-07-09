using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MinihuronBackend.Models
{
    [Table("archives")]
    public class Archive
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("Name")]
        [Required(ErrorMessage = "Possible null value for Name of Archive")]
        public string? Name { get; set; }
        
        [Column("FolderId")]
        [Required(ErrorMessage = "possible null value for FolderId")]
        public int FolderId { get; set; }

        [Column("CreationDate")]
        [Required(ErrorMessage = "possible null value for creationDate")]
        public DateOnly? CreationDate { get; set; }

        [Column("FilePath")]
        [Required(ErrorMessage = "possible null value for FilePath")]
        public string? FilePath { get; set; }

        [JsonIgnore]
        public Folder? Folder { get; set; }
    }
}