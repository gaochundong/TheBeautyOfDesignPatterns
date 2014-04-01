using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Implementation1
{
  public abstract class Facade
  {
    public abstract void Operation();
  }

  public class ConcreteFacade : Facade
  {
    public override void Operation()
    {
      // we could use any factory here
      // or use IoC here
      SubsystemClassA subsystemClassA = new SubsystemClassA();
      SubsystemClassB subsystemClassB = new SubsystemClassB();

      subsystemClassA.BehaviorA();
      subsystemClassB.BehaviorB();
    }
  }

  public class SubsystemClassA
  {
    public void BehaviorA()
    {
      // do something
    }
  }

  public class SubsystemClassB
  {
    public void BehaviorB()
    {
      // do something
    }
  }

  public class Client
  {
    public void TestCase1()
    {
      Facade facade = new ConcreteFacade();
      facade.Operation();
    }
  }
}
