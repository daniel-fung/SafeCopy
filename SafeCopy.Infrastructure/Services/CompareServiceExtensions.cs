using SafeCopy.Infrastructure.Models;
using System;

namespace SafeCopy.Infrastructure.Services
{
  public static class CompareServiceExtensions
  {
    public static bool AreSame(this ICompareService compareService, string file1, string file2)
    {
      if (string.IsNullOrWhiteSpace(file1))
      {
        throw new ArgumentNullException("file1");
      }

      if (string.IsNullOrWhiteSpace(file2))
      {
        throw new ArgumentNullException("file2");
      }

      var f1 = new File(file1);
      var f2 = new File(file2);

      return compareService.AreSame(f1, f2);
    }
  }
}
