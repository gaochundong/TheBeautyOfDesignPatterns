using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Implementation1
{
  public abstract class State
  {
    public abstract string Name { get; }
    public abstract void Handle(Context context);
  }

  public class Context
  {
    private State _state;

    public Context()
    {
    }

    public void SetState(State state)
    {
      _state = state;
      Console.WriteLine("Current State: {0}", _state.Name);
    }

    public void Request()
    {
      _state.Handle(this);
    }
  }

  public class ConcreteStateA : State
  {
    public override string Name { get { return "StateA"; } }

    public override void Handle(Context context)
    {
      Console.WriteLine(Name + " is handling context.");

      // change context state
      context.SetState(new ConcreteStateB());
    }
  }

  public class ConcreteStateB : State
  {
    public override string Name { get { return "StateB"; } }

    public override void Handle(Context context)
    {
      Console.WriteLine(Name + " is handling context.");

      // change context state
      context.SetState(new ConcreteStateA());
    }
  }

  public class Client
  {
    public void TestCase1()
    {
      var context = new Context();
      context.SetState(new ConcreteStateA());

      context.Request();
      context.Request();
    }
  }
}
