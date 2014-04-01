using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern.Implementation4
{
  public class Singleton
  {
    private static Singleton _instance;
    private static readonly object _syncRoot = new object();

    // the constructor should be protected or private
    protected Singleton()
    {
    }

    public static Singleton Instance()
    {
      // double-check locking
      if (_instance == null)
      {
        lock (_syncRoot)
        {
          if (_instance == null)
          {
            // use lazy initialization
            _instance = new Singleton();
          }
        }
      }

      return _instance;
    }
  }
}
