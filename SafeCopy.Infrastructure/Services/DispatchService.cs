using System;

namespace SafeCopy.Infrastructure.Services
{
  public class DispatchService : IDispatchService
  {
    private readonly IFileService _fileService;
    private readonly IDirectoryService _directoryService;

    public DispatchService(IFileService fileService, IDirectoryService directoryService)
    {
      _fileService = Throw.IfNull(fileService, "fileService");
      _directoryService = Throw.IfNull(directoryService, "directoryService");
    }

    public bool Copy(string source, string target)
    {
      if (_fileService.Exists(source))
      {
        var sourceFile = _fileService.OpenFile(source);
        var targetFile = _fileService.Copy(sourceFile, target);

        return targetFile != null;
      }

      if (_directoryService.Exists(source))
      {
        var sourceDir = _directoryService.OpenDirectory(source);
        var targetDir = sourceDir.CopyTo(target);

        return targetDir != null;
      }

      throw new ArgumentException("Unknown source.");
    }
  }
}
