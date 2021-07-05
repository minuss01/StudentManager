using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WEB.DTOs.Student
{
    public class FileDto
    {
        [Required]
        [DisplayName("Plik")]
        public IFormFile File { get; set; }
    }
}
