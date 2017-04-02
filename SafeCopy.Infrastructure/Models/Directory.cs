using SafeCopy.Infrastructure.Services;
using System;
using System.Linq;

namespace SafeCopy.Infrastructure.Models
{
  public class Directory : IDirectory
  {
    private readonly IDirectoryService _directoryService;
    private readonly IFileService _fileService;

    public Directory(string path, IDirectoryService directoryService, IFileService fileService)
    {
      if (directoryService == null)
      {
        throw new ArgumentNullException("directoryService");
      }
      _directoryService = directoryService;

      if (string.IsNullOrEmpty(path))
      {
        throw new ArgumentNullException("path");
      }

      if (!_directoryService.Exists(path))
      {
        throw new ArgumentException("path", "Directory does not exsit.");
      }

      if (fileService == null)
      {
        throw new ArgumentNullException("fileService");
      }

      Path = path;
      _fileService = fileService;
    }

    public string Path { get; private set; }

    public string Name
    {
      get
      {
        //return _directoryService.GetDirectoryName(this);
        var parts = Path.Split(_directoryService.DirectorySeparator);
        return parts.Last();
      }
    }

    public IDirectory CopyTo(string destBasePath)
    {
      if (string.IsNullOrWhiteSpace(destBasePath))
      {
        throw new ArgumentException("destBasePath cannot be null or white space.");
      }

      var destPath = destBasePath + _directoryService.DirectorySeparator + Name;
      if (_directoryService.Exists(destPath))
      {
        throw new InvalidOperationException("Target directory " + destPath + " already exists.");
      }

      var destDir = _directoryService.CreateDirectory(destPath);

      var files = _directoryService.GetFiles(this);
      foreach (var filePath in files)
      {
        var sourceFile = _fileService.OpenFile(filePath);
        var destFile = sourceFile.Copy(destDir.Path + _directoryService.DirectorySeparator + sourceFile.Name);

        if (sourceFile.GetCheckSum() == destFile.GetCheckSum())
        {
          throw new InvalidOperationException("Source and destinatin file have different check sum.");
        }
      }

      return destDir;
    }

    public override string ToString()
    {
      return Path;
    }
  }
}
