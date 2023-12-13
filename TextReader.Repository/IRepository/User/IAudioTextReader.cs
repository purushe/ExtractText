using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TextReader.Repository.IRepository.User
{
  public interface IAudioTextReader
  {
    Task<string> TranscribeAudio(IFormFile audioFile);
  }
}
