using System;
using System.Collections.Generic;
using System.Text;

namespace TextReader.Utility
{
  public class DtParam<T>
  {
    public T Search { get; set; }

    public int Size { get; set; }

    public int PageNumber { get; set; }

    public DtSort Sort { get; set; }

    public object Data { get; set; }
  }

  public class DtSort
  {
    public string Dir { get; set; }

    public string Prop { get; set; }

    public const string Asc = "asc";

    public const string Desc = "desc";
  }

  public class DTParameters
  {
    public int PageIndex
    {
      get
      {
        if (Length == 0)
        {
          return 0;
        }

        return Start / Length;
      }
    }

    public int Draw { get; set; }

    public DTColumn[] Columns { get; set; }

    public DTOrder[] Order { get; set; }

    public int Start { get; set; }

    public int Length { get; set; }

    public DTSearch Search { get; set; }

    public string SortOrder => Columns != null && Order != null && Order.Length != 0 ? Columns[Order[0].Column].Data + (Order[0].Dir == DTOrderDir.DESC ? " " + Order[0].Dir : string.Empty) : null;
  }

  public class DTColumn
  {
    public string Data { get; set; }

    public string Name { get; set; }

    public bool Searchable { get; set; }

    public bool Orderable { get; set; }

    public DTSearch Search { get; set; }
  }

  public class DTOrder
  {
    public int Column { get; set; }

    public DTOrderDir Dir { get; set; }
  }

  public class DTSearch
  {
    public string Value { get; set; }

    public bool Regex { get; set; }
  }

  public enum DTOrderDir
  {
    ASC,
    DESC
  }
}
