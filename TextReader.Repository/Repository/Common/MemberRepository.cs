using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using TextReader.Repository.IRepository.Common;

namespace TextReader.Repository.Repository.Common
{
  public class MemberRepository : IMemberRepository
  {
    private readonly IHttpContextAccessor httpContext;
    public MemberRepository(IHttpContextAccessor httpContext)
    {
      this.httpContext = httpContext;
    }

    public string GetUserEmail()
    {
      return httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.Email);
    }

    public string GetUserId()
    {
      return httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.Name);
    }

    public bool IsAuthenticated()
    {
      return httpContext.HttpContext.User.Identity.IsAuthenticated;
    }
  }
}
