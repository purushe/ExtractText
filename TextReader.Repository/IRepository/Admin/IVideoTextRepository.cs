using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TextReader.Repository.IRepository.Admin
{
  public interface IVideoTextRepository
  {
    Task<string> TranscribeVideo(IFormFile audioFile);
  }
}
