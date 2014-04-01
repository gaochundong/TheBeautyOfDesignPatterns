using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Implementation2
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

  public interface ITarget
  {
    string Request();
  }

  public class Adapter : ChildAdaptee, ITarget
  {
    public Adapter()
    {
    }

    public string Request()
    {
      return base.SpecificRequest();
    }
  }

  public class Client
  {
    public void TestCase2()
    {
      ITarget target = new Adapter();
      var result = target.Request();
    }
  }
}
