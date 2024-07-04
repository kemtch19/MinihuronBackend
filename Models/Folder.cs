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

        [Required(ErrorMessage ="Possible null value of parent folder")]
        public string? parentFolder { get; set; }

        [Required(ErrorMessage = "Possible null value")]
        public int? UserId{ get; set; }
        public User? User{ get; set; }

        [JsonIgnore]
        public List<Archive>? Archives { get; set; }
    }
}