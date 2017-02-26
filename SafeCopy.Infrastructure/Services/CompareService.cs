﻿using SafeCopy.Infrastructure.Models;
using System;

namespace SafeCopy.Infrastructure.Services
{
  public class CompareService : ICompareService
  {
    private readonly IFileService _fileService;

    public CompareService(IFileService fileService)
    {
      if (fileService == null)
      {
        throw new ArgumentNullException("fileService");
      }

      _fileService = fileService;
    }

    public bool AreSame(File file1, File file2)
    {
      if (file1 == null)
      {
        throw new ArgumentNullException("file1");
      }

      if (file2 == null)
      {
        throw new ArgumentNullException("file2");
      }

      var checkSum1 = _fileService.GetCheckSum(file1);
      var checkSum2 = _fileService.GetCheckSum(file2);

      return checkSum1.Equals(checkSum2);
    }
  }
}
