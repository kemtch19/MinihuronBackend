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

        [Required(ErrorMessage = "Possible null value for Name of Archive")]
        public string? Name { get; set; }
        
        [Required(ErrorMessage = "possible null value for creationDate")]
        public DateOnly? CreationDate { get; set; }

        public int FolderId { get; set; }

        [JsonIgnore]
        public List<Folder>? Folders { get; set; }
    }
}