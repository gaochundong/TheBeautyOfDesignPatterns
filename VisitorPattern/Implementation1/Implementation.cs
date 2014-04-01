using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern.Implementation1
{
  public abstract class Element
  {
    public abstract void Accept(Visitor visitor);
  }

  public abstract class Visitor
  {
    public abstract void Visit(ConcreteElementA element);
    public abstract void Visit(ConcreteElementB element);
  }

  public class ObjectStructure
  {
    private List<Element> _elements = new List<Element>();

    public void Attach(Element element)
    {
      _elements.Add(element);
    }

    public void Detach(Element element)
    {
      _elements.Remove(element);
    }

    public void Accept(Visitor visitor)
    {
      foreach (var element in _elements)
      {
        element.Accept(visitor);
      }
    }
  }

  public class ConcreteElementA : Element
  {
    public string Name { get; set; }

    public override void Accept(Visitor visitor)
    {
      visitor.Visit(this);
    }
  }

  public class ConcreteElementB : Element
  {
    public string ID { get; set; }

    public override void Accept(Visitor visitor)
    {
      visitor.Visit(this);
    }
  }

  public class ConcreteVisitorA : Visitor
  {
    public override void Visit(ConcreteElementA element)
    {
      Console.WriteLine(
        "ConcreteVisitorA visited ConcreteElementA : {0}", 
        element.Name);
    }

    public override void Visit(ConcreteElementB element)
    {
      Console.WriteLine(
        "ConcreteVisitorA visited ConcreteElementB : {0}", 
        element.ID);
    }
  }

  public class ConcreteVisitorB : Visitor
  {
    public override void Visit(ConcreteElementA element)
    {
      Console.WriteLine(
        "ConcreteVisitorB visited ConcreteElementA : {0}", 
        element.Name);
    }

    public override void Visit(ConcreteElementB element)
    {
      Console.WriteLine(
        "ConcreteVisitorB visited ConcreteElementB : {0}", 
        element.ID);
    }
  }

  public class Client
  {
    public void TestCase1()
    {
      var objectStructure = new ObjectStructure();

      objectStructure.Attach(new ConcreteElementA());
      objectStructure.Attach(new ConcreteElementB());

      objectStructure.Accept(new ConcreteVisitorA());
      objectStructure.Accept(new ConcreteVisitorB());
    }
  }
}
