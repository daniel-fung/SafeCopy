using System.IO;

namespace SafeCopy.Infrastructure.Models
{
  public interface IFile
  {
    string Name { get; }
    string Path { get; }

    IFile Copy(string targetPath);
    CheckSum GetCheckSum();
    FileStream OpenRead();
    string ToString();
  }
}