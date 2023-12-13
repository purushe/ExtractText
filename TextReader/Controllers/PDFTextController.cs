using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TextReader.Models;
using TextReader.Repository.IRepository.Admin;
using TextReader.Repository.IRepository.User;

namespace TextReader.Controllers
{
  [Authorize]
  public class PDFTextController : Controller
  {
    private readonly IPDFTextReader textReader;

    public PDFTextController(IPDFTextReader textReader)
    {
      this.textReader = textReader;
    }

    [HttpGet]
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
