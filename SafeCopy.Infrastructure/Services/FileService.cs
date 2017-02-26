using SafeCopy.Infrastructure.Models;
using System;

namespace SafeCopy.Infrastructure.Services
{
  public class FileService : IFileService
  {
    private readonly ICheckSumService _checkSumService;

    public FileService(ICheckSumService checkSumService)
    {
      _checkSumService = checkSumService;
    }

    public string GetCheckSum(File file)
    {
      if (file == null)
      {
        throw new ArgumentNullException("file");
      }

      string checkSum;
      using (var stream = file.OpenRead())
      {
        checkSum = _checkSumService.GetCheckSum(stream);
      }

      return checkSum;
    }
  }
}
