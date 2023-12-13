using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TextReader.Repository.IRepository.User
{
  public interface IImageTextReader
  {
    string ExtractTextFromImage(byte[] imageBytes, string tessdataPath);
    //Task<string> ExtractTextFromImage(IFormFile imageFile);
  }
}
