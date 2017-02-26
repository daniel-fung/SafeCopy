using SafeCopy.Infrastructure.Models;

namespace SafeCopy.Infrastructure.Services
{
  public interface ICompareService
  {
    bool AreSame(File file1, File file2);
  }
}