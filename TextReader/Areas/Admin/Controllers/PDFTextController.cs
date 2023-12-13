using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TextReader.Areas.Admin.Models;
using TextReader.Repository.IRepository.Admin;
using static TextReader.Utility.Constant;

namespace TextReader.Areas.Admin.Controllers
{
  [Area(AreaConstants.AdminArea)]
  [Authorize(Roles = "Admin")]
  public class PDFTextController : Controller
  {
    private readonly IPDFTextRepository textReader;

    public PDFTextController(IPDFTextRepository textReader)
    {
      this.textReader = textReader;
    }

    [HttpGet]
    [Route("Admin/PDFText/Index")]
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public ActionResult<ExtractedTextModel> Pdf([FromForm] IFormFile pdfFile)
    {
      if (pdfFile == null || pdfFile.Length == 0)
      {
        ViewBag.Error = "No file uploaded.";
        return View();
      }

      using (var stream = pdfFile.OpenReadStream())
      {
        var text = textReader.ExtractTextFromPdfStream(stream);
        var model = new ExtractedTextModel { ExtractedText = text };
        return View("PDFText", model);
      }
    }
  }
}
