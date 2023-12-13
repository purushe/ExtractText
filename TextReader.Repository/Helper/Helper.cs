using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextReader.Repository.Helper
{
  public static class Helper
  {
    public static SelectList GetStatus()
    {
      return new SelectList(new List<dynamic>
        {
            new { Text = "Active", Value = false },
            new { Text = "Inactive", Value = true }
        }, "Value", "Text");
    }
  }

}
