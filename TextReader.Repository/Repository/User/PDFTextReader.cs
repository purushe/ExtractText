using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;
using System.Text;
using TextReader.Repository.IRepository.User;

namespace TextReader.Repository.Repository.User
{
  public class PDFTextReader : IPDFTextReader
  {
    public string ExtractTextFromPdfStream(Stream pdfStream)
    {
      try
      {
        var text = new StringBuilder();
        using (var reader = new PdfReader(pdfStream))
        {
          for (int page = 1; page <= reader.NumberOfPages; page++)
          {
            var strategy = new SimpleTextExtractionStrategy();
            var currentText = PdfTextExtractor.GetTextFromPage(reader, page, strategy);
            text.Append(currentText);
          }
        }
        return text.ToString();
      }
      catch
      {
        throw;
      }

    }
  }
}
