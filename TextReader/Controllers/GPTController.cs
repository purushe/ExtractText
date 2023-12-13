using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TextReader.Models;
using TextReader.Repository.IRepository.User;

namespace TextReader.Controllers
{
  [Authorize]
  public class GPTController : Controller
  {
    private readonly IGPTRepository _gptRepository;

    public GPTController(IGPTRepository gptRepository)
    {
      _gptRepository = gptRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public IActionResult GetAnswer(string prompt)
    {
      if (prompt == null)
      {
        ViewBag.Error = "Please ask your Question.";
        return View("Index");
      }

      try
      {
        var messages = new List<ChatMessage>
        {
            new ChatMessage { Sender = "You", Message = prompt, Timestamp = DateTime.Now },
            new ChatMessage { Sender = "ChatGPT", Message = _gptRepository.GetAnswer(prompt), Timestamp = DateTime.Now }
        };

        ViewBag.ChatHistory = messages;
        return View("Index");
      }
      catch (Exception ex)
      {
        ViewBag.Error = $"Something went wrong: {ex.Message}";
        return View("Index");
      }
    }
  }
}
