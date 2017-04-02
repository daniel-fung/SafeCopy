namespace SafeCopy.Infrastructure.Models
{
  public interface IDirectory
  {
    string Name { get; }
    string Path { get; }

    IDirectory CopyTo(string destBasePath);
    string ToString();
  }
}