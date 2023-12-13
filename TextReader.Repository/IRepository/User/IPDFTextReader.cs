using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextReader.Repository.IRepository.User
{
  public interface IPDFTextReader
  {
    string ExtractTextFromPdfStream(Stream pdfStream);
  }
}
