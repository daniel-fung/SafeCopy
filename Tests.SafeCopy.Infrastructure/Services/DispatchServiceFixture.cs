using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using SafeCopy.Infrastructure.Models;
using SafeCopy.Infrastructure.Services;

namespace Tests.SafeCopy.Infrastructure.Services
{
  [TestClass]
  public class DispatchServiceFixture
  {
    private IDirectoryService MockDirectoryService { get; set; }
    private IFileService MockFileService { get; set; }

    private IUnityContainer Container { get; set; }

    private DispatchService DispatchService { get; set; }

    [TestInitialize]
    public void Initialize()
    {
      Container = new UnityContainer();

      MockDirectoryService = MockRepository.GenerateMock<IDirectoryService>();
      Container.RegisterInstance(MockDirectoryService);

      MockFileService = MockRepository.GenerateMock<IFileService>();
      Container.RegisterInstance(MockFileService);

      DispatchService = Container.Resolve<DispatchService>();
    }

    [TestMethod]
    public void Copy_Source_Is_File_Success()
    {
      var sourceFile = Utilities.GetRandomString();
      var targetFile = Utilities.GetRandomString();

      MockDirectoryService.Stub(mock => mock.Exists(Arg.Is(sourceFile)))
                          .Return(false);
      MockDirectoryService.Stub(mock => mock.Exists(Arg.Is(targetFile)))
                          .Return(false);

      var mockSourceFile = MockRepository.GenerateMock<IFile>();

      MockFileService.Stub(mock => mock.Exists(Arg.Is(sourceFile)))
                     .Return(true);
      MockFileService.Stub(mock => mock.OpenFile(Arg.Is(sourceFile)))
                     .Return(mockSourceFile);
      MockFileService.Stub(mock => mock.Exists(Arg.Is(targetFile)))
                     .Return(false);

      MockFileService.Expect(mock => mock.Copy(Arg<File>.Is.Anything, Arg.Is(targetFile)))
                     .Return(MockRepository.GenerateStub<IFile>());

      // Act
      var result = DispatchService.Copy(sourceFile, targetFile);

      // Assert
      Assert.IsTrue(result);
      MockFileService.VerifyAllExpectations();
    }

    [TestMethod]
    public void Copy_Source_Is_Directory_Success()
    {
      var sourceDir = Utilities.GetRandomString();
      var targetDir = Utilities.GetRandomString();

      var mockSourceDir = MockRepository.GenerateMock<IDirectory>();
      var mockTargetDir = MockRepository.GenerateMock<IDirectory>();
      mockSourceDir.Expect(mock => mock.CopyTo(Arg.Is(targetDir)))
                   .Return(mockTargetDir);

      MockDirectoryService.Stub(mock => mock.Exists(Arg.Is(sourceDir)))
                          .Return(true);
      MockDirectoryService.Stub(mock => mock.OpenDirectory(Arg.Is(sourceDir)))
                          .Return(mockSourceDir);

      MockDirectoryService.Stub(mock => mock.Exists(Arg.Is(targetDir)))
                          .Return(false);

      MockFileService.Stub(mock => mock.Exists(Arg.Is(sourceDir)))
                     .Return(false);
      MockFileService.Stub(mock => mock.Exists(Arg.Is(targetDir)))
                     .Return(false);

      // Act
      var result = DispatchService.Copy(sourceDir, targetDir);

      // Assert
      Assert.IsTrue(result);
      mockSourceDir.VerifyAllExpectations();
    }
  }
}
