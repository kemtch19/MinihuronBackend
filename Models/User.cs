using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MinihuronBackend.Models
{
    [Table("users")]
    public class User
    {
        [Required]
        [Column("id_user")]
        public int Id{ get; set; }

        [Column("Name")]
        [Required(ErrorMessage = "Possible null Name User")]
        public string? Name{ get; set; }

        [Column("Email")]
        [Required(ErrorMessage = "Possible null Email User")]
        public string? Email{ get; set; }

        [Column("Password")]
        [Required(ErrorMessage = "Possible null password User")]
        public string? Password{ get; set;}

        [Column("Phone")]
        [Required(ErrorMessage = "Possible null phone User")]
        public string? Phone { get; set; }

        [Column("Token")]
        [Required(ErrorMessage = "Possible null Token User")]
        public string? Token{ get; set; }

        [JsonIgnore]
        public Folder? Folder { get; set; }
    }
}