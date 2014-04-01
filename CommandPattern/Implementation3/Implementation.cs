using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Implementation3
{
  public abstract class Command
  {
    public abstract void Execute();
  }

  public class ConcreteCommand : Command
  {
    private Action<string> _action;
    private string _state;

    public ConcreteCommand(Action<string> action, string state)
    {
      _action = action;
      _state = state;
    }

    public override void Execute()
    {
      _action.Invoke(_state);
    }
  }

  public class Receiver
  {
    public void Action(string state)
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
    public void TestCase3()
    {
      Receiver receiver = new Receiver();
      Command cmd = new ConcreteCommand(receiver.Action, "Hello World");

      Invoker invoker = new Invoker();
      invoker.StoreCommand(cmd);

      invoker.Invoke();
    }
  }
}
