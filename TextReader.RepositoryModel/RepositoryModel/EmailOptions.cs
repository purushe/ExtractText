using System;
using System.Collections.Generic;
using System.Text;

namespace TextReader.RepositoryModel.RepositoryModel
{
  public class EmailOptions
  {
    public List<string> ToEmails { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public List<KeyValuePair<string, string>> PlaceHolders { get; set; }
  }
}
