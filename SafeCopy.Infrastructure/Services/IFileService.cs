using SafeCopy.Infrastructure.Models;

namespace SafeCopy.Infrastructure.Services
{
  public interface IFileService
  {
    IFile OpenFile(string path);

    bool Exists(string path);

    string GetFileName(IFile file);

    System.IO.Stream ReadFile(IFile file);

    IFile Copy(IFile source, string targetPath);
  }
}