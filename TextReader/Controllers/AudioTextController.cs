using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TextReader.Repository.IRepository.Admin;
using TextReader.Repository.IRepository.User;

namespace TextReader.Controllers
{
  [Authorize]
  public class AudioTextController : Controller
  {
    private readonly IAudioTextReader _audioTextReader;

    public AudioTextController(IAudioTextReader audioTextReader)
    {
      _audioTextReader = audioTextReader;
    }

    [HttpGet]
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
