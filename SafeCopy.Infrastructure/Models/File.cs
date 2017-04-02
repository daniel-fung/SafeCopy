using SafeCopy.Infrastructure.Services;
using System;

namespace SafeCopy.Infrastructure.Models
{
  public class File : IFile
  {
    private readonly IFileService _fileService;
    private readonly ICheckSumService _checkSumService;

    public File(string path, IFileService fileService, ICheckSumService checkSumService)
    {
      if (string.IsNullOrEmpty(path))
      {
        throw new ArgumentNullException("path");
      }
      Path = path;

      if (fileService == null)
      {
        throw new ArgumentNullException("fileService");
      }
      _fileService = fileService;
            
      if (!_fileService.Exists(path))
      {
        throw new ArgumentException("path", "File does not exists.");
      }

      if (checkSumService == null)
      {
        throw new ArgumentNullException("checkSumService");
      }
      _checkSumService = checkSumService;
    }

    public string Path { get; private set; }

    public string Name
    {
      get
      {
        return _fileService.GetFileName(this);
      }
    }

    public System.IO.FileStream OpenRead()
    {
      return _fileService.ReadFile(this) as System.IO.FileStream;
    }

    public CheckSum GetCheckSum()
    {
      var checkSum = _checkSumService.ComputeCheckSum(OpenRead());
      return checkSum;
    }

    public IFile Copy(string targetPath)
    {
      if (string.IsNullOrWhiteSpace(targetPath))
      {
        throw new ArgumentException("destPath cannot be null or white space.");
      }

      var targetFile = _fileService.Copy(this, targetPath);
      return targetFile;
    }

    public override string ToString()
    {
      return Path;
    }
  }
}
