using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.Implementation2
{
  public abstract class AbstractOrInterfaceOfFactoryKit
  {
    public abstract AbstractOrInterfaceOfProductA CreateProductA();
    public abstract AbstractOrInterfaceOfProductB CreateProductB();
  }

  public abstract class AbstractOrInterfaceOfProductA
  {
    public abstract AbstractOrInterfaceOfProductA Clone();
  }

  public abstract class AbstractOrInterfaceOfProductB
  {
    public abstract AbstractOrInterfaceOfProductB Clone();
  }

  public class ConcreteFactoryKit1 : AbstractOrInterfaceOfFactoryKit
  {
    public override AbstractOrInterfaceOfProductA CreateProductA()
    {
      return new ConcreteProductA();
    }

    public override AbstractOrInterfaceOfProductB CreateProductB()
    {
      return new ConcreteProductB();
    }
  }

  public class ConcreteFactoryKit2 : AbstractOrInterfaceOfFactoryKit
  {
    private AbstractOrInterfaceOfProductA _prototypeOfProductA;
    private AbstractOrInterfaceOfProductB _prototypeOfProductB;

    public ConcreteFactoryKit2(
      AbstractOrInterfaceOfProductA prototypeOfProductA,
      AbstractOrInterfaceOfProductB prototypeOfProductB)
    {
      _prototypeOfProductA = prototypeOfProductA;
      _prototypeOfProductB = prototypeOfProductB;
    }

    public override AbstractOrInterfaceOfProductA CreateProductA()
    {
      return _prototypeOfProductA.Clone();
    }

    public override AbstractOrInterfaceOfProductB CreateProductB()
    {
      return _prototypeOfProductB.Clone();
    }
  }

  public class ConcreteProductA : AbstractOrInterfaceOfProductA
  {
    public override AbstractOrInterfaceOfProductA Clone()
    {
      return new ConcreteProductA();
    }
  }

  public class ConcreteProductB : AbstractOrInterfaceOfProductB
  {
    public override AbstractOrInterfaceOfProductB Clone()
    {
      return new ConcreteProductB();
    }
  }

  public class Client
  {
    public void TestCase2()
    {
      AbstractOrInterfaceOfFactoryKit kit1 = new ConcreteFactoryKit1();
      AbstractOrInterfaceOfProductA productA1 = kit1.CreateProductA();
      AbstractOrInterfaceOfProductB productB1 = kit1.CreateProductB();

      AbstractOrInterfaceOfFactoryKit kit2 = new ConcreteFactoryKit2(productA1, productB1);
      AbstractOrInterfaceOfProductA productA2 = kit2.CreateProductA();
      AbstractOrInterfaceOfProductB productB2 = kit2.CreateProductB();
    }
  }
}
