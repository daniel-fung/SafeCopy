using System;

namespace Tests.SafeCopy.Infrastructure
{
  internal static class Utilities
  {
    public static string GetRandomString()
    {
      var guid = Guid.NewGuid().ToString();
      return guid;
    }
  }
}
