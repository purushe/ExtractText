namespace TextReader.Utility
{
  public enum Status
  {
    Active = 1,
    InActive = 2,
    Pending = 3,
    Deleted = 4,
    Cancelled = 5,
    Completed = 6
  }

  public enum StatusCode
  {
    success = 1,
    failed = 0,
    error = 3
  }
}
