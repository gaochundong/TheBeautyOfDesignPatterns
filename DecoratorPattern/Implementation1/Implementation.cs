using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Implementation1
{
  public abstract class Component
  {
    public abstract void Operation();
  }

  public class ConcreteComponent : Component
  {
    public override void Operation()
    {
      // do something
    }
  }

  public abstract class Decorator : Component
  {
    private Component _component;

    public Decorator(Component component)
    {
      _component = component;
    }

    public override void Operation()
    {
      _component.Operation();
    }
  }

  public class ConcreteDecorator : Decorator
  {
    public ConcreteDecorator(Component component)
      : base(component)
    {
    }

    public override void Operation()
    {
      base.Operation();
      AddedBehavior();
    }

    private void AddedBehavior()
    {
      // do some other things
    }
  }

  public class Client
  {
    public void TestCase1()
    {
      Component component1 = new ConcreteComponent();
      Component component2 = new ConcreteDecorator(component1);

      component2.Operation();
    }
  }
}
