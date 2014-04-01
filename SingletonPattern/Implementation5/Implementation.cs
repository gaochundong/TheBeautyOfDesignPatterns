using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern.Implementation5
{
  public class Singleton
  {
    private static Dictionary<string, Singleton> _registry
      = new Dictionary<string, Singleton>();

    // the constructor should be protected or private
    protected Singleton()
    {
    }

    public static Singleton Instance(string name)
    {
      if (!_registry.ContainsKey(name))
      {
        if (name == "Apple")
        {
          _registry.Add(name, new AppleSingleton());
        }
        else if (name == "Orange")
        {
          _registry.Add(name, new OrangeSingleton());
        }
      }

      return _registry[name];
    }
  }

  public class AppleSingleton : Singleton
  {
  }

  public class OrangeSingleton : Singleton
  {
  }
}

