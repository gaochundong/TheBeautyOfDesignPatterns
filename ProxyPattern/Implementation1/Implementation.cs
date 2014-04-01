using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Implementation1
{
  public abstract class Subject
  {
    public abstract string Name { get; }
    public abstract void Request();
  }

  public class ConcreteSubject : Subject
  {
    private string _name;

    public ConcreteSubject(string name)
    {
      _name = name;
    }

    public override string Name { get { return _name; } }

    public override void Request()
    {
      // do something
    }
  }

  public class Proxy : Subject
  {
    private Subject _realSubject = null;
    private string _name;

    public Proxy(string name)
    {
      _name = name;
    }

    public override string Name { get { return _name; } }

    public override void Request()
    {
      if (_realSubject == null)
        LoadRealSubject();

      _realSubject.Request();
    }

    private void LoadRealSubject()
    {
      // do some heavy things
      _realSubject = new ConcreteSubject(_name);
    }
  }

  public class Client
  {
    public void TestCase1()
    {
      Subject subject = new Proxy("SubjectName");
      var subjectName = subject.Name;
      subject.Request();
    }
  }
}
