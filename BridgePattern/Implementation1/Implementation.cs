using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.Implementation1
{
  public class Abstraction
  {
    protected IImplementor _implementor;

    public Abstraction(IImplementor implementor)
    {
      _implementor = implementor;
    }

    public virtual void Operation()
    {
      _implementor.OperationImp1();
    }
  }

  public interface IImplementor
  {
    void OperationImp1();
  }

  public class ConcreteImplementorA : IImplementor
  {
    public void OperationImp1()
    {
      // do something
    }
  }

  public class ConcreteImplementorB : IImplementor
  {
    public void OperationImp1()
    {
      // do something
    }
  }

  public class ChildAbstraction : Abstraction
  {
    public ChildAbstraction(IImplementor implementor)
      : base(implementor)
    {
    }

    public override void Operation()
    {
      base.Operation();
      // do some others
    }
  }

  public class Client
  {
    public void TestCase1()
    {
      IImplementor implementor1 = new ConcreteImplementorA();
      IImplementor implementor2 = new ConcreteImplementorB();

      Abstraction abstraction1 = new Abstraction(implementor1);
      Abstraction abstraction2 = new ChildAbstraction(implementor2);

      abstraction1.Operation();
      abstraction2.Operation();
    }
  }
}
