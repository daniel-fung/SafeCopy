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

      var file1 = args[0];
      var file2 = args[1];

      var container = new UnityContainer();
      var module = container.Resolve<Module>();

      var compareService = container.Resolve<ICompareService>();
      Console.WriteLine(compareService.AreSame(file1, file2));
    }
  }
}
