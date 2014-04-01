using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern.Implementation1
{
  public abstract class Flyweight
  {
    public abstract string Identifier { get; }
    public abstract void Operation(string extrinsicState);
  }

  public class ConcreteFlyweight : Flyweight
  {
    public override string Identifier
    {
      get { return "hello"; }
    }

    public override void Operation(string extrinsicState)
    {
      // do something
    }
  }

  public class FlyweightFactory
  {
    private Dictionary<string, Flyweight> _pool
      = new Dictionary<string, Flyweight>();

    public Flyweight CreateFlyweight(string identifier)
    {
      if (!_pool.ContainsKey(identifier))
      {
        Flyweight flyweight = new ConcreteFlyweight();
        _pool.Add(flyweight.Identifier, flyweight);
      }

      return _pool[identifier];
    }
  }

  public class Client
  {
    public void TestCase1()
    {
      FlyweightFactory factory = new FlyweightFactory();
      Flyweight flyweight1 = factory.CreateFlyweight("hello");
      Flyweight flyweight2 = factory.CreateFlyweight("hello");
      flyweight1.Operation("extrinsic state");
      flyweight2.Operation("extrinsic state");
    }
  }
}
