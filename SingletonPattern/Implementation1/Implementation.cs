using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern.Implementation1
{
  public class Singleton
  {
    private static Singleton _instance = new Singleton();

    // the constructor should be protected or private
    protected Singleton()
    {
    }

    public static Singleton Instance()
    {
      return _instance;
    }
  }
}
