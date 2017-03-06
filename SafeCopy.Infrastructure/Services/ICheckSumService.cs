using SafeCopy.Infrastructure.Models;
using System.IO;

namespace SafeCopy.Infrastructure.Services
{
  public interface ICheckSumService
  {
    CheckSum ComputeCheckSum(Stream stream);
  }
}