using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern.Implementation3
{
  public class Singleton
  {
    private static Singleton _instance;

    // the constructor should be protected or private
    protected Singleton()
    {
    }

    public static Singleton Instance()
    {
      if (_instance == null)
      {
        // use lazy initialization
        _instance = new Singleton();
      }

      return _instance;
    }

    public void Reset()
    {
      _instance = null;
    }
  }
}

