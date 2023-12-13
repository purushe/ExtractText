using System;
using System.Collections.Generic;
using System.Text;

namespace TextReader.Repository.IRepository.Common
{
  public interface IMemberRepository
  {
    string GetUserId();
    bool IsAuthenticated();
    string GetUserEmail();
  }
}
