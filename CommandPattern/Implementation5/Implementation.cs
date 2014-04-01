using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Implementation5
{
  public class WeakAction
  {
    public WeakAction(Action action)
    {
      Method = action.Method;
      Reference = new WeakReference(action.Target);
    }

    protected MethodInfo Method { get; private set; }
    protected WeakReference Reference { get; private set; }

    public bool IsAlive
    {
      get { return Reference.IsAlive; }
    }

    public object Target
    {
      get { return Reference.Target; }
    }

    public void Invoke()
    {
      if (Method != null && IsAlive)
      {
        Method.Invoke(Target, null);
      }
    }
  }

  public abstract class Command
  {
    public abstract void Execute();
  }

  public class ConcreteCommand : Command
  {
    private WeakAction _action;

    public ConcreteCommand(Action action)
    {
      _action = new WeakAction(action);
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
    public void TestCase5()
    {
      Receiver receiver = new Receiver();
      Command cmd = new ConcreteCommand(receiver.Action);

      Invoker invoker = new Invoker();
      invoker.StoreCommand(cmd);

      invoker.Invoke();
    }
  }
}
