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
  public class VideoTextController : Controller
  {
    private readonly IVideoTextReader videoTextReader;
    public VideoTextController(IVideoTextReader videoTextReader)
    {
      this.videoTextReader = videoTextReader;
    }
    [HttpGet]
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Video(IFormFile videoFile)
    {
      if (videoFile == null || videoFile.Length == 0)
      {
        ViewBag.Error = "No file uploaded.";
        return View();
      }
      try
      {
        string transcribedText = await videoTextReader.TranscribeVideo(videoFile);
        return View("VideoText", transcribedText);
      }
      catch (Exception ex)
      {
        ViewBag.Error = $"Something went wrong: {ex.Message}";
        return View("Error");
      }
    }
  }
}
