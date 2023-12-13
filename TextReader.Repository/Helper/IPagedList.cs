using System.Collections.Generic;

namespace TextReader.Repository.Helper
{

  public interface IPagedList<T> : IList<T>
  {
    int PageIndex { get; }
    int PageSize { get; }
    int TotalCount { get; }
    int TotalPages { get; }
    int SearchCount { get; }
    bool HasPreviousPage { get; }
    bool HasNextPage { get; }
  }
}
