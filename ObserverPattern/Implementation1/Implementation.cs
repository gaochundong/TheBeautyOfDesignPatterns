using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Implementation1
{
  public abstract class Observer
  {
    public abstract void Update();
  }

  public abstract class Subject
  {
    private List<Observer> _observers = new List<Observer>();

    public void Attach(Observer observer)
    {
      _observers.Add(observer);
    }

    public void Detach(Observer observer)
    {
      _observers.Remove(observer);
    }

    public void Notify()
    {
      foreach (var observer in _observers)
      {
        observer.Update();
      }
    }
  }

  public class ConcreteSubject : Subject
  {
    private string _state;

    public string State
    {
      get
      {
        return _state;
      }
      set
      {
        _state = value;
        Notify();
      }
    }
  }

  public class ConcreteObserver : Observer
  {
    private ConcreteSubject _subject;

    public ConcreteObserver(string name, ConcreteSubject subject)
    {
      Name = name;
      _subject = subject;
    }

    public string Name { get; private set; }

    public override void Update()
    {
      string subjectState = _subject.State;
      Console.WriteLine(Name + ": " + subjectState);
    }
  }

  public class Client
  {
    public void TestCase1()
    {
      var subject = new ConcreteSubject();
      subject.Attach(new ConcreteObserver("Observer 1", subject));
      subject.Attach(new ConcreteObserver("Observer 2", subject));
      subject.Attach(new ConcreteObserver("Observer 3", subject));

      subject.State = "Hello World";
    }
  }
}
