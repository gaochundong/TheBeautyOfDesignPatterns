using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.Implementation4
{
  public abstract class AbstractOrInterfaceOfFactoryKit
  {
    public abstract AbstractOrInterfaceOfProductA CreateProductA();
    public abstract AbstractOrInterfaceOfProductB CreateProductB();
    public abstract AbstractOrInterfaceOfProductC CreateProductC<TC>()
      where TC : AbstractOrInterfaceOfProductC, new();
  }

  public abstract class AbstractOrInterfaceOfProductA
  {
  }

  public abstract class AbstractOrInterfaceOfProductB
  {
  }

  public abstract class AbstractOrInterfaceOfProductC
  {
  }

  public class ConcreteFactoryKit1<TA, TB> : AbstractOrInterfaceOfFactoryKit
    where TA : AbstractOrInterfaceOfProductA, new()
    where TB : AbstractOrInterfaceOfProductB, new()
  {
    public override AbstractOrInterfaceOfProductA CreateProductA()
    {
      return new TA();
    }

    public override AbstractOrInterfaceOfProductB CreateProductB()
    {
      return new TB();
    }

    public override AbstractOrInterfaceOfProductC CreateProductC<TC>()
    {
      return new TC();
    }
  }

  public class ConcreteProductA : AbstractOrInterfaceOfProductA
  {
  }

  public class ConcreteProductB : AbstractOrInterfaceOfProductB
  {
  }

  public class ConcreteProductC : AbstractOrInterfaceOfProductC
  {
  }

  public class Client
  {
    public void TestCase4()
    {
      AbstractOrInterfaceOfFactoryKit kit = new ConcreteFactoryKit1<ConcreteProductA, ConcreteProductB>();
      AbstractOrInterfaceOfProductA productA = kit.CreateProductA();
      AbstractOrInterfaceOfProductB productB = kit.CreateProductB();
      AbstractOrInterfaceOfProductC productC = kit.CreateProductC<ConcreteProductC>();
    }
  }
}
