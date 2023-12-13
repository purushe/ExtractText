using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TextReader.Repository.IRepository.Admin
{
  public interface IImageTextRepository
  {
    string ExtractTextFromImage(byte[] imageBytes, string tessdataPath);
    //Task<string> ExtractTextFromImage(IFormFile imageFile);
  }
}
