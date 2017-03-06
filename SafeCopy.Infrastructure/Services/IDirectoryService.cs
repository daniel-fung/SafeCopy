using SafeCopy.Infrastructure.Models;
using System.Collections.Generic;

namespace SafeCopy.Infrastructure.Services
{
  public interface IDirectoryService
  {
    Directory CreateDirectory(string path);

    Directory OpenDirectory(string path);

    bool Exists(string path);

    string GetDirectoryName(Directory dir);

    IEnumerable<string> GetFiles(Directory dir);

    char DirectorySeparator { get; }
  }
}
