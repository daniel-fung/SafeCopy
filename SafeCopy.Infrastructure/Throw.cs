using System;

namespace SafeCopy.Infrastructure
{
  public static class Throw
  {
    public static T IfNull<T>(T value, string name)
    {
      if (value == null)
      {
        throw new ArgumentNullException(name);
      }

      return value;
    }
  }
}
