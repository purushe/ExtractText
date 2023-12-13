using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextReader.Repository.IRepository.Admin
{
  public interface IPDFTextRepository
  {
    string ExtractTextFromPdfStream(Stream pdfStream);
  }
}
