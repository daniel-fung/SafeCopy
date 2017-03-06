using System.Text;

namespace SafeCopy.Infrastructure.Models
{
  public class CheckSum
  {
    private readonly byte[] _bytes;

    private volatile string _value;

    public CheckSum(byte[] bytes)
    {
      _bytes = new byte[bytes.Length];
      bytes.CopyTo(_bytes, 0);
    }

    public string Value
    {
      get
      {
        if (string.IsNullOrEmpty(_value))
        {
          lock(this)
          {
            if (string.IsNullOrEmpty(_value))
            {
              StringBuilder sb = new StringBuilder();
              for (var i = 0; i < _bytes.Length; i++)
              {
                sb.AppendFormat("{0:X2}", _bytes[i]);
              }

              _value = sb.ToString();
            }
          }
        }

        return _value;
      }
    }

    public override int GetHashCode()
    {
      return Value.GetHashCode();
    }

    public override bool Equals(object obj)
    {
      var another = obj as CheckSum;
      if (another == null)
      {
        return false;
      }

      return another.Value == Value;
    }

    public override string ToString()
    {
      return Value;
    }
  }
}
