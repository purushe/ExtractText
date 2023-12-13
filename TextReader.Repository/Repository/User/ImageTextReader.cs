using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using Tesseract;
using TextReader.Repository.IRepository.User;

namespace TextReader.Repository.Repository.User
{
  public class ImageTextReader : IImageTextReader
  {
    public string ExtractTextFromImage(byte[] imageBytes, string tessdataPath)
    {
      try
      {
        if (imageBytes == null || imageBytes.Length == 0)
        {
          throw new Exception("Image data is empty or null.");
        }
        using (var engine = new TesseractEngine(tessdataPath, "eng", EngineMode.Default))
        using (var img = Pix.LoadTiffFromMemory(imageBytes))
        using (var page = engine.Process(img))
        {
          return page.GetText();
        }
      }
      catch
      {
        throw;
      }
    }
    //public async Task<string> ExtractTextFromImage(IFormFile imageFile)
    //{
    //  try
    //  {
    //    string apiKey = "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";
    //    string token = apiKey;
    //    string imageToTextEndpoint = "https://api.openai.com/v1/vision/models/davinci/Image/completions";

    //    using (HttpClient client = new HttpClient())
    //    {
    //      client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

    //      using (var content = new MultipartFormDataContent())
    //      {
    //        content.Add(new StreamContent(imageFile.OpenReadStream()), "files", imageFile.FileName);

    //        HttpResponseMessage response = await client.PostAsync(imageToTextEndpoint, content);
    //        response.EnsureSuccessStatusCode();

    //        string jsonResponse = await response.Content.ReadAsStringAsync();

    //        string extractedText = ExtractTextFromJson(jsonResponse);

    //        return extractedText;
    //      }
    //    }
    //  }
    //  catch (Exception ex)
    //  {
    //    throw ex;
    //  }
    //}
    //private string ExtractTextFromJson(string jsonResponse)
    //{
    //  int startIndex = jsonResponse.IndexOf("\"text\":") + "\"text\":".Length;
    //  int endIndex = jsonResponse.LastIndexOf("\"");

    //  if (startIndex >= 0 && endIndex >= 0)
    //  {
    //    string extractedText = jsonResponse.Substring(startIndex, endIndex - startIndex);
    //    extractedText = extractedText.TrimStart('"');
    //    return extractedText;
    //  }
    //  else
    //  {
    //    throw new Exception("Unable to extract text from JSON response.");
    //  }
    //}
  }
}
