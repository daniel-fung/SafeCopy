using SafeCopy.Infrastructure.Models;
using System.Collections.Generic;

namespace SafeCopy.Infrastructure.Services
{
  public interface IDirectoryService
  {
    IDirectory CreateDirectory(string path);

    IDirectory OpenDirectory(string path);

    bool Exists(string path);

    string GetDirectoryName(IDirectory dir);

    IEnumerable<string> GetFiles(IDirectory dir);

    char DirectorySeparator { get; }
  }
}
