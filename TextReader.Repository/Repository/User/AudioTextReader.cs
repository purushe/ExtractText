using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using TextReader.Repository.IRepository.User;

public class AudioTextReader : IAudioTextReader
{
  public async Task<string> TranscribeAudio(IFormFile audioFile)
  {
    try
    {
      string apiKey = "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";
      string token = apiKey;
      string speechToTextEndpoint = "https://api.openai.com/v1/audio/transcriptions";

      using (HttpClient client = new HttpClient())
      {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        using (var content = new MultipartFormDataContent())
        {
          content.Add(new StreamContent(audioFile.OpenReadStream()), "file", audioFile.FileName);
          content.Add(new StringContent("whisper-1"), "model");

          HttpResponseMessage response = await client.PostAsync(speechToTextEndpoint, content);
          response.EnsureSuccessStatusCode();

          string jsonResponse = await response.Content.ReadAsStringAsync();

          string transcribedText = ExtractTextFromJson(jsonResponse);

          return transcribedText;
        }
      }
    }
    catch
    {
      throw;
    }
  }

  private string ExtractTextFromJson(string jsonResponse)
  {
    int startIndex = jsonResponse.IndexOf("\"text\":") + "\"text\":".Length;
    int endIndex = jsonResponse.LastIndexOf("\"");

    if (startIndex >= 0 && endIndex >= 0)
    {
      string extractedText = jsonResponse.Substring(startIndex, endIndex - startIndex);
      extractedText = extractedText.TrimStart('"');
      return extractedText;
    }
    else
    {
      throw new Exception("Unable to extract text from JSON response.");
    }
  }
}
