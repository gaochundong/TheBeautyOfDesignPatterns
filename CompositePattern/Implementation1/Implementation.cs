using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.Implementation1
{
  public abstract class Component
  {
    protected List<Component> _children = new List<Component>();

    public abstract void Operation();

    public virtual void Add(Component component)
    {
      _children.Add(component);
    }

    public virtual void Remove(Component component)
    {
      _children.Remove(component);
    }

    public virtual IEnumerable<Component> GetChildren()
    {
      return _children;
    }
  }

  public class Leaf : Component
  {
    public override void Operation()
    {
      // do something
    }

    public override void Add(Component component)
    {
      throw new InvalidOperationException();
    }

    public override void Remove(Component component)
    {
      throw new InvalidOperationException();
    }

    public override IEnumerable<Component> GetChildren()
    {
      throw new InvalidOperationException();
    }
  }

  public class Composite : Component
  {
    public override void Operation()
    {
      foreach (var child in _children)
      {
        child.Operation();
      }
      // may do something
    }
  }

  public class Client
  {
    public void TestCase1()
    {
      Component component1 = new Leaf();
      Component component2 = new Composite();

      component2.Add(component1);

      component1.Operation();
      component2.Operation();
    }
  }
}
