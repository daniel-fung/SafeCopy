using SafeCopy.Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace SafeCopy.Infrastructure.Services
{
  public class DirectoryService : IDirectoryService
  {
    private readonly IFileService _fileService;

    public DirectoryService(IFileService fileService)
    {
      if (fileService == null)
      {
        throw new ArgumentNullException("fileService");
      }

      _fileService = fileService;
    }

    public char DirectorySeparator
    {
      get
      {
        return System.IO.Path.DirectorySeparatorChar;
      }
    }

    public Directory CreateDirectory(string path)
    {
      if (Exists(path))
      {
        throw new ArgumentException("path already exists.");
      }

      var info = System.IO.Directory.CreateDirectory(path);
      return new Directory(path, this, _fileService);
    }

    public Directory OpenDirectory(string path)
    {
      if (!Exists(path))
      {
        throw new ArgumentException("path does not exist.");
      }

      return new Directory(path, this, _fileService);
    }

    public bool Exists(string path)
    {
      if (string.IsNullOrWhiteSpace(path))
      {
        throw new ArgumentException("path cannot be null or empty.");
      }

      return System.IO.Directory.Exists(path);
    }

    public string GetDirectoryName(Directory dir)
    {
      if (dir == null)
      {
        throw new ArgumentNullException("dir");
      }

      return System.IO.Path.GetDirectoryName(dir.Path);
    }

    public IEnumerable<string> GetFiles(Directory dir)
    {
      if (dir == null)
      {
        throw new ArgumentNullException("dir");
      }

      return System.IO.Directory.EnumerateFiles(dir.Path);
    }
  }
}
