using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Implementation2
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

  public class ConcreteDecorator : Component
  {
    private Component _component;

    public ConcreteDecorator(Component component)
    {
      _component = component;
    }

    public override void Operation()
    {
      _component.Operation();
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
