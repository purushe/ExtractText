using System;
using System.Collections.Generic;
using System.Text;

namespace TextReader.Repository.IRepository.User
{
  public interface IGPTRepository
  {
    string GetAnswer(string prompt);
  }
}
