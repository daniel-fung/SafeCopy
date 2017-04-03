using Microsoft.Practices.Unity;
using SafeCopy.Infrastructure.Services;
using System;

namespace SafeCopy.Infrastructure
{
  public class Module
  {
    private readonly IUnityContainer _container;

    public Module(IUnityContainer container)
    {
      _container = Throw.IfNull(container, "container");

      _container.RegisterType<ICheckSumService, MD5CheckSumService>();
      _container.RegisterType<IFileService, FileService>();
      _container.RegisterType<ICompareService, CompareService>();
      _container.RegisterType<IDirectoryService, DirectoryService>();
      _container.RegisterType<IDispatchService, DispatchService>();
    }
  }
}
