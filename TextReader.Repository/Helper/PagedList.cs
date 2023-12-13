using System.Collections.Generic;
using System.Linq;

namespace TextReader.Repository.Helper
{

  public class PagedList<T> : List<T>, IPagedList<T>
  {

    public PagedList() { }

    public PagedList(IQueryable<T> source, int pageIndex, int pageSize, int totalCount, int searchCount = 0)
    {
      if (pageSize == -1)
        pageSize = int.MaxValue - 1;

      SearchCount = searchCount;
      TotalCount = totalCount;
      TotalPages = TotalCount / pageSize;

      if (TotalCount % pageSize > 0)
        TotalPages++;

      PageSize = pageSize;
      PageIndex = pageIndex;
      AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
    }


    public PagedList(IQueryable<T> source, int pageIndex, int pageSize = 10, int searchCount = 0)
    {
      if (pageSize == -1)
        pageSize = int.MaxValue - 1;

      int total = source.Count();
      SearchCount = searchCount;
      TotalCount = total;
      TotalPages = total / pageSize;

      if (total % pageSize > 0)
        TotalPages++;

      PageSize = pageSize;
      PageIndex = pageIndex;
      AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
    }


    public PagedList(IList<T> source, int pageIndex, int pageSize)
    {
      TotalCount = source.Count();
      TotalPages = TotalCount / pageSize;

      if (TotalCount % pageSize > 0)
        TotalPages++;

      PageSize = pageSize;
      PageIndex = pageIndex;
      AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
    }


    public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount, int searchCount = 0)
    {
      SearchCount = searchCount;
      TotalCount = totalCount;
      TotalPages = TotalCount / pageSize;

      if (TotalCount % pageSize > 0)
        TotalPages++;
      SearchCount = searchCount;
      PageSize = pageSize;
      PageIndex = pageIndex;
      AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
    }

    public int PageIndex { get; protected set; }
    public int PageSize { get; protected set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public int SearchCount { get; set; }

    public bool HasPreviousPage
    {
      get { return PageIndex > 0; }
    }

    public bool HasNextPage
    {
      get { return PageIndex + 1 < TotalPages; }
    }
  }

  public class IPageList<T>
  {
    public IPageList()
    {
      Data = new List<T>();
    }
    public IEnumerable<T> Data { get; set; }
    public long TotalRecords { get; set; }
    public long TotalFilteredRecords { get; set; }
  }
}
