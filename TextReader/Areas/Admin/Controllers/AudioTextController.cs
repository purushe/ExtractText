using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TextReader.Repository.IRepository.Admin;
using TextReader.Repository.IRepository.User;
using static TextReader.Utility.Constant;

namespace TextReader.Areas.Admin.Controllers
{
  [Area(AreaConstants.AdminArea)]
  [Authorize(Roles = "Admin")]
  public class AudioTextController : Controller
  {
    private readonly IAudioTextRepository _audioTextReader;

    public AudioTextController(IAudioTextRepository audioTextReader)
    {
      _audioTextReader = audioTextReader;
    }

    [HttpGet]
    [Route("Admin/AudioText/Index")]
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Audio(IFormFile audioFile)
    {
      if (audioFile == null || audioFile.Length == 0)
      {
        ViewBag.Error = "No file uploaded.";
        return View();
      }
      try
      {
        string transcribedText = await _audioTextReader.TranscribeAudio(audioFile);
        return View("AudioText", transcribedText);
      }
      catch (Exception ex)
      {
        ViewBag.Error = $"Something went wrong: {ex.Message}";
        return View();
      }
    }
  }
}
