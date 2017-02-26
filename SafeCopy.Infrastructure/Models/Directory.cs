using System;

namespace SafeCopy.Infrastructure.Models
{
  public class Directory
  {
    public Directory(string path)
    {
      if (string.IsNullOrEmpty(path))
      {
        throw new ArgumentNullException("path");
      }

      if (!System.IO.Directory.Exists(path))
      {
        throw new ArgumentException("path", "Directory does not exsit.");
      }

      Path = path;
    }

    public string Path { get; private set; }
  }
}
