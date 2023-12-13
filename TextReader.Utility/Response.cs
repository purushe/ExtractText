using System;
using System.Collections.Generic;

namespace TextReader.Utility
{
  public class Response
  {
    public class ResponseDataList<T> : ResponseStatus
    {
      public IEnumerable<T> Data { get; set; }
      public long Count { get; set; }
      public long SearchCount { get; set; }
    }

    public class ResponseData<T> : ResponseStatus
    {
      public T Data { get; set; }

      public int Count()
      {
        throw new NotImplementedException();
      }
    }

    public class ResponseStatus
    {
      public bool Status { get; set; }
      public string Message { get; set; }
    }
  }
}
