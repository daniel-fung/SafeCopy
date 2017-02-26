using System.IO;

namespace SafeCopy.Infrastructure.Services
{
  public interface ICheckSumService
  {
    string GetCheckSum(Stream stream);
  }
}