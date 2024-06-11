using System.ComponentModel.DataAnnotations;

namespace MovieApi.Modules.File.Models
{
    public class Upload
    {
        [Required]
        public IFormFile File { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
    }
}