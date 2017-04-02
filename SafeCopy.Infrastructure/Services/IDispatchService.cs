namespace SafeCopy.Infrastructure.Services
{
  public interface IDispatchService
  {
    bool Copy(string source, string target);
  }
}
