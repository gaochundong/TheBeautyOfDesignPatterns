using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Implementation7
{
  public abstract class Command
  {
    public abstract void Execute();
  }

  public class MacroCommand : Command
  {
    private List<Command> _cmdList = new List<Command>();

    public MacroCommand()
    {
    }

    public void Add(Command cmd)
    {
      _cmdList.Add(cmd);
    }

    public void Remove(Command cmd)
    {
      _cmdList.Remove(cmd);
    }

    public override void Execute()
    {
      foreach (var cmd in _cmdList)
      {
        cmd.Execute();
      }
    }
  }

  public class ConcreteCommand1 : Command
  {
    private Receiver _receiver;

    public ConcreteCommand1(Receiver receiver)
    {
      _receiver = receiver;
    }

    public override void Execute()
    {
      _receiver.Action1();
    }
  }

  public class ConcreteCommand2 : Command
  {
    private Receiver _receiver;

    public ConcreteCommand2(Receiver receiver)
    {
      _receiver = receiver;
    }

    public override void Execute()
    {
      _receiver.Action2();
    }
  }

  public class Receiver
  {
    public void Action1()
    {
      // do something
    }

    public void Action2()
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
    public void TestCase7()
    {
      Receiver receiver = new Receiver();
      Command cmd1 = new ConcreteCommand1(receiver);
      Command cmd2 = new ConcreteCommand2(receiver);
      MacroCommand macro = new MacroCommand();
      macro.Add(cmd1);
      macro.Add(cmd2);

      Invoker invoker = new Invoker();
      invoker.StoreCommand(macro);

      invoker.Invoke();
    }
  }
}
