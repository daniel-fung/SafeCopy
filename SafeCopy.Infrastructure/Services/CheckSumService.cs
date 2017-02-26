using System;
using System.IO;
using System.Text;

namespace SafeCopy.Infrastructure.Services
{
  public class CheckSumService : ICheckSumService
  {
    public string GetCheckSum(Stream stream)
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

      var checkSum = ConvertToDisplayString(hash);
      return checkSum;
    }

    private static string ConvertToDisplayString(byte[] array)
    {
      if (array == null)
      {
        throw new ArgumentNullException("array");
      }

      StringBuilder sb = new StringBuilder();
      for (var i = 0; i < array.Length; i++)
      {
        sb.AppendFormat("{0:X2}", array[i]);
      }

      return sb.ToString();
    }
  }
}
