using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TextReader.Repository.IRepository.User
{
  public interface IVideoTextReader
  {
    Task<string> TranscribeVideo(IFormFile audioFile);
  }
}
