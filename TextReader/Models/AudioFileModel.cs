using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

public class AudioFileModel
{
  [Required(ErrorMessage = "Please select an audio file.")]
  public IFormFile AudioFile { get; set; }
}

