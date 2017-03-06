using Microsoft.Practices.Unity;
using SafeCopy.Infrastructure;
using SafeCopy.Infrastructure.Services;
using System;

namespace SafeCopy
{
  public class Program
  {
    static void Main(string[] args)
    {
      if (args.Length == 0)
      {
        Console.Out.WriteLine("GUI version is not supported yet.");
        Environment.Exit(1);
      }
      
      if (args.Length != 2)
      {
        Console.Out.WriteLine("Incorrect number of arguments.");
        Environment.Exit(1);
      }

      var path1 = args[0];
      var path2 = args[1];

      var container = new UnityContainer();
      var module = container.Resolve<Module>();

      //var compareService = container.Resolve<ICompareService>();
      //Console.WriteLine(compareService.AreSame(path1, path2));

      //var fileService = container.Resolve<IFileService>();
      //var file1 = fileService.OpenFile(path1);
      //var file2 = file1.Copy(path2);

      var directoryService = container.Resolve<IDirectoryService>();
      var dir1 = directoryService.OpenDirectory(path1);
      var dir2 = dir1.CopyTo(path2);
    }
  }
}
