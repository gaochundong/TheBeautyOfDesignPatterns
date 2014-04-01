using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Implementation6
{
  public abstract class Command
  {
    public abstract void Execute();
    public abstract void Unexecute();
    public abstract void Reexecute();
  }

  public class ConcreteCommand : Command
  {
    private Receiver _receiver;
    private string _state;
    private string _lastState;

    public ConcreteCommand(Receiver receiver, string state)
    {
      _receiver = receiver;
      _state = state;
    }

    public override void Execute()
    {
      _lastState = _receiver.Name;
      _receiver.ChangeName(_state);
    }

    public override void Unexecute()
    {
      _receiver.ChangeName(_lastState);
      _lastState = string.Empty;
    }

    public override void Reexecute()
    {
      Unexecute();
      Execute();
    }
  }

  public class Receiver
  {
    public string Name { get; private set; }

    public void ChangeName(string name)
    {
      // do something
      Name = name;
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

    public void UndoInvoke()
    {
      if (_cmd != null)
      {
        _cmd.Unexecute();
      }
    }
  }

  public class Client
  {
    public void TestCase6()
    {
      Receiver receiver = new Receiver();
      Command cmd = new ConcreteCommand(receiver, "Hello World");

      Invoker invoker = new Invoker();
      invoker.StoreCommand(cmd);

      invoker.Invoke();
      invoker.UndoInvoke();
    }
  }
}
