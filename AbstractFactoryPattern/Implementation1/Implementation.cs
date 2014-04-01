using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.Implementation1
{
  public abstract class AbstractOrInterfaceOfFactoryKit
  {
    public abstract AbstractOrInterfaceOfProductA CreateProductA();
    public abstract AbstractOrInterfaceOfProductB CreateProductB();
  }

  public abstract class AbstractOrInterfaceOfProductA
  {
  }

  public abstract class AbstractOrInterfaceOfProductB
  {
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

  public class ConcreteProductA : AbstractOrInterfaceOfProductA
  {
  }

  public class ConcreteProductB : AbstractOrInterfaceOfProductB
  {
  }

  public class Client
  {
    public void TestCase1()
    {
      AbstractOrInterfaceOfFactoryKit kit = new ConcreteFactoryKit1();
      AbstractOrInterfaceOfProductA productA = kit.CreateProductA();
      AbstractOrInterfaceOfProductB productB = kit.CreateProductB();
    }
  }
}
