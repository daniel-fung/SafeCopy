using SafeCopy.Infrastructure.Models;
using System;
using System.IO;
using System.Text;

namespace SafeCopy.Infrastructure.Services
{
  public class MD5CheckSumService : ICheckSumService
  {
    public CheckSum ComputeCheckSum(Stream stream)
    {
      if (stream == null)
      {
        throw new ArgumentNullException("stream");
      }

      byte[] hash;
      using (var md5 = System.Security.Cryptography.MD5.Create())
      {
        hash = md5.ComputeHash(stream);
      }

      var checkSum = new CheckSum(hash);
      return checkSum;
    }
  }
}
