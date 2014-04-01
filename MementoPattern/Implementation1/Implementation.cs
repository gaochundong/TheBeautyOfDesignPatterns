using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPattern.Implementation1
{
  public class Memento
  {
    private readonly string _state;

    public Memento(string state)
    {
      _state = state;
    }

    public string GetState()
    {
      return _state;
    }
  }

  public class Originator
  {
    public string State { get; set; }

    public Memento CreateMemento()
    {
      return (new Memento(State));
    }

    public void SetMemento(Memento memento)
    {
      State = memento.GetState();
    }
  }

  public class Caretaker
  {
    public Memento Memento { get; set; }
  }

  public class Client
  {
    public void TestCase1()
    {
      var originator = new Originator { State = "State A" };
      Console.WriteLine(originator.State);

      var memento = originator.CreateMemento();
      var caretaker = new Caretaker { Memento = memento };

      originator.State = "State B";
      Console.WriteLine(originator.State);

      originator.SetMemento(caretaker.Memento);
      Console.WriteLine(originator.State);
    }
  }
}
