using System;
using System.IO;

namespace SafeCopy.Infrastructure.Models
{
  public class File
  {
    public File(string path)
    {
      if (string.IsNullOrEmpty(path))
      {
        throw new ArgumentNullException("path");
      }

      if (!System.IO.File.Exists(path))
      {
        throw new ArgumentException("path", "File does not exists.");
      }

      Path = path;
    }

    public string Path { get; private set; }

    public FileStream OpenRead()
    {
      return System.IO.File.OpenRead(Path);
    }
  }
}
