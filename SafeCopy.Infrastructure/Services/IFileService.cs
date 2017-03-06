using SafeCopy.Infrastructure.Models;

namespace SafeCopy.Infrastructure.Services
{
  public interface IFileService
  {
    File OpenFile(string path);

    bool Exists(string path);

    string GetFileName(File file);

    System.IO.Stream ReadFile(File file);

    File Copy(File source, string targetPath);
  }
}