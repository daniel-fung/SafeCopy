using SafeCopy.Infrastructure.Models;
using System;

namespace SafeCopy.Infrastructure.Services
{
  public class FileService : IFileService
  {
    private readonly ICheckSumService _checkSumService;

    public FileService(ICheckSumService checkSumService)
    {
      _checkSumService = Throw.IfNull(checkSumService, "checkSumService");
    }

    public IFile OpenFile(string path) => new File(path, this, _checkSumService);

    public bool Exists(string path)
    {
      if (string.IsNullOrWhiteSpace(path))
      {
        throw new ArgumentException("path cannot be null or empty.");
      }

      return System.IO.File.Exists(path);
    }

    public string GetFileName(IFile file)
    {
      if (file == null)
      {
        throw new ArgumentNullException("file");
      }

      return System.IO.Path.GetFileName(file.Path);
    }

    public System.IO.Stream ReadFile(IFile file)
    {
      if (file == null)
      {
        throw new ArgumentNullException("file");
      }

      return System.IO.File.OpenRead(file.Path);
    }

    public IFile Copy(IFile source, string targetPath)
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
