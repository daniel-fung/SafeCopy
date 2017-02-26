using SafeCopy.Infrastructure.Models;

namespace SafeCopy.Infrastructure.Services
{
  public interface IFileService
  {
    string GetCheckSum(File fileName);
  }
}