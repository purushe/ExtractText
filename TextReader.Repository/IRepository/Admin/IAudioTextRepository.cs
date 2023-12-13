using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TextReader.Repository.IRepository.Admin
{
  public interface IAudioTextRepository
  {
    Task<string> TranscribeAudio(IFormFile audioFile);
  }
}
