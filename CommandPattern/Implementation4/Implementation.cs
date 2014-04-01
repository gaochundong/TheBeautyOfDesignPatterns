using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Implementation4
{
  public abstract class Command
  {
    public abstract void Execute();
  }

  public class ConcreteCommand<T, S> : Command
  {
    private Action<T, S> _action;
    private T _state1;
    private S _state2;

    public ConcreteCommand(Action<T, S> action, T state1, S state2)
    {
      _action = action;
      _state1 = state1;
      _state2 = state2;
    }

    public override void Execute()
    {
      _action.Invoke(_state1, _state2);
    }
  }

  public class Receiver
  {
    public void Action(string state1, int state2)
    {
      // do something
    }
  }

  public class Invoker
  {
    private Command _cmd;

    public void StoreCommand(Command cmd)
    {
      _cmd = cmd;
    }

    public void Invoke()
    {
      if (_cmd != null)
      {
        _cmd.Execute();
      }
    }
  }

  public class Client
  {
    public void TestCase4()
    {
      Receiver receiver = new Receiver();
      Command cmd = new ConcreteCommand<string, int>(
        receiver.Action, "Hello World", 250);

      Invoker invoker = new Invoker();
      invoker.StoreCommand(cmd);

      invoker.Invoke();
    }
  }
}
