using System.Collections.Generic;

namespace TextReader.Repository.Helper
{
  public class DataTableList<T>
  {
    public int draw { get; set; }
    public long recordsTotal { get; set; }
    public long recordsFiltered { get; set; }
    public IEnumerable<T> data { get; set; }
  }
}
