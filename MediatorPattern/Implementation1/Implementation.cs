using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern.Implementation1
{
  public abstract class Colleague
  {
    protected Mediator _mediator;

    public Colleague(Mediator mediator)
    {
      _mediator = mediator;
    }

    public abstract void Send(string message);
    public abstract void Notify(string message);
  }

  public abstract class Mediator
  {
    public abstract void SendMessage(Colleague sender, string message);
  }

  public class ConcreteMediator : Mediator
  {
    private ConcreteColleague1 _colleague1;
    private ConcreteColleague2 _colleague2;

    public ConcreteColleague1 Colleague1
    {
      set { _colleague1 = value; }
    }

    public ConcreteColleague2 Colleague2
    {
      set { _colleague2 = value; }
    }

    public override void SendMessage(Colleague sender, string message)
    {
      if (sender == _colleague1)
      {
        _colleague2.Notify(message);
      }
      else if (sender == _colleague2)
      {
        _colleague1.Notify(message);
      }
    }
  }

  public class ConcreteColleague1 : Colleague
  {
    public ConcreteColleague1(Mediator mediator)
      : base(mediator)
    {
    }

    public override void Send(string message)
    {
      _mediator.SendMessage(this, message);
    }

    public override void Notify(string message)
    {
      Console.WriteLine("Colleague1 gets message: " + message);
    }
  }

  public class ConcreteColleague2 : Colleague
  {
    public ConcreteColleague2(Mediator mediator)
      : base(mediator)
    {
    }

    public override void Send(string message)
    {
      _mediator.SendMessage(this, message);
    }

    public override void Notify(string message)
    {
      Console.WriteLine("Colleague2 gets message: " + message);
    }
  }

  public class Client
  {
    public void TestCase1()
    {
      var mediator = new ConcreteMediator();

      var colleague1 = new ConcreteColleague1(mediator);
      var colleague2 = new ConcreteColleague2(mediator);

      mediator.Colleague1 = colleague1;
      mediator.Colleague2 = colleague2;

      colleague1.Send("How are you?");
      colleague2.Send("Fine, Thank you!");
    }
  }
}
