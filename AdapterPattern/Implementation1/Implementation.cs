using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Implementation1
{
  public class ParentAdaptee
  {
    public virtual string SpecificRequest()
    {
      return "ParentAdaptee";
    }
  }

  public class ChildAdaptee : ParentAdaptee
  {
    public override string SpecificRequest()
    {
      return "ChildAdaptee";
    }
  }

  public class Target
  {
    public virtual string Request()
    {
      return "Target";
    }
  }

  public class Adapter : Target
  {
    private ParentAdaptee _adaptee;

    public Adapter(ParentAdaptee adaptee)
    {
      _adaptee = adaptee;
    }

    public override string Request()
    {
      return _adaptee.SpecificRequest();
    }
  }

  public class Client
  {
    public void TestCase1()
    {
      ParentAdaptee adaptee = new ChildAdaptee();
      Target target = new Adapter(adaptee);
      var result = target.Request();
    }
  }
}
