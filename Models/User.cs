using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MinihuronBackend.Models
{
    public class User
    {
        [Required]
        public int Id{ get; set; }

        [Required(ErrorMessage = "Possible null Name User")]
        public string? Name{ get; set; }

        [Required(ErrorMessage = "Possible null Email User")]
        public string? Email{ get; set; }

        [Required(ErrorMessage = "Possible null password User")]
        public string? Password{ get; set;}

        [Required(ErrorMessage = "Possible null phone User")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Possible null Token User")]
        public string? Token{ get; set; }

        [JsonIgnore]
        public List<Folder>? Folders { get; set; }
    }
}