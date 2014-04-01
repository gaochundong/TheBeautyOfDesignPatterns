using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Implementation2
{
  public abstract class Command
  {
    public abstract void Execute();
  }

  public class ConcreteCommand : Command
  {
    private Action _action;

    public ConcreteCommand(Action action)
    {
      _action = action;
    }

    public override void Execute()
    {
      _action.Invoke();
    }
  }

  public class Receiver
  {
    public void Action()
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
    public void TestCase2()
    {
      Receiver receiver = new Receiver();
      Command cmd = new ConcreteCommand(receiver.Action);

      Invoker invoker = new Invoker();
      invoker.StoreCommand(cmd);

      invoker.Invoke();
    }
  }
}
