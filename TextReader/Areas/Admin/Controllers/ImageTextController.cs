using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using ImageMagick;
using Microsoft.AspNetCore.Authorization;
using TextReader.Repository.IRepository.Admin;
using static TextReader.Utility.Constant;

namespace TextReader.Areas.Admin.Controllers
{
  [Area(AreaConstants.AdminArea)]
  [Authorize(Roles = "Admin")]
  public class ImageTextController : Controller
  {
    private readonly IImageTextRepository imageTextReader;
    private readonly string tessdataPath;

    public ImageTextController(IImageTextRepository imageTextReader)
    {
      this.imageTextReader = imageTextReader;
      tessdataPath = @"tessdata";
    }

    [HttpGet]
    [Route("Admin/Imagetext/Index")]
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Image(IFormFile imageFile)
    {
      if (imageFile != null && imageFile.Length > 0)
      {
        using (var memoryStream = new MemoryStream())
        {
          imageFile.CopyTo(memoryStream);

          // Convert the image to TIFF using ImageMagick
          using (var image = new MagickImage(memoryStream.ToArray()))
          {
            image.Format = MagickFormat.Tiff;
            memoryStream.Position = 0;
            image.Write(memoryStream);
          }

          var imageBytes = memoryStream.ToArray();
          string extractedText = imageTextReader.ExtractTextFromImage(imageBytes, tessdataPath);
          var model = new ImageTextModel
          {
            ExtractedText = extractedText,
            ImageBytes = imageBytes
          };
          return View("ImageText", model);
        }
      }
      return View("ImageText", null);
    }
  }
}
