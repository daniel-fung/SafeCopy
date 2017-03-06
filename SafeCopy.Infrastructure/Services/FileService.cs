using SafeCopy.Infrastructure.Models;
using System;

namespace SafeCopy.Infrastructure.Services
{
  public class FileService : IFileService
  {
    private readonly ICheckSumService _checkSumService;

    public FileService(ICheckSumService checkSumService)
    {
      if (checkSumService == null)
      {
        throw new ArgumentNullException("checkSumService");
      }

      _checkSumService = checkSumService;
    }

    public File OpenFile(string path)
    {
      return new File(path, this, _checkSumService);
    }

    public bool Exists(string path)
    {
      if (string.IsNullOrWhiteSpace(path))
      {
        throw new ArgumentException("path cannot be null or empty.");
      }

      return System.IO.File.Exists(path);
    }

    public string GetFileName(File file)
    {
      if (file == null)
      {
        throw new ArgumentNullException("file");
      }

      return System.IO.Path.GetFileName(file.Path);
    }

    public System.IO.Stream ReadFile(File file)
    {
      if (file == null)
      {
        throw new ArgumentNullException("file");
      }

      return System.IO.File.OpenRead(file.Path);
    }

    public File Copy(File source, string targetPath)
    {
      if (source == null)
      {
        throw new ArgumentNullException("source");
      }

      if (string.IsNullOrWhiteSpace(targetPath))
      {
        throw new ArgumentException("targetPath cannot be null or empty.");
      }

      if (System.IO.File.Exists(targetPath))
      {
        throw new InvalidOperationException("targetPath already exists.");
      }

      System.IO.File.Copy(source.Path, targetPath);

      var target = new File(targetPath, this, _checkSumService);
      return target;
    }
  }
}
