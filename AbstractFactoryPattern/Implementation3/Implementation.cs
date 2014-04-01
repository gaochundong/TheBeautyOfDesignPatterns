using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.Implementation3
{
  public enum ProductCategory
  {
    ProductA,
    ProductB,
  }

  public abstract class AbstractOrInterfaceOfFactoryKit
  {
    public abstract object CreateProduct(ProductCategory category);
  }

  public abstract class AbstractOrInterfaceOfProductA
  {
  }

  public abstract class AbstractOrInterfaceOfProductB
  {
  }

  public class ConcreteFactoryKit1 : AbstractOrInterfaceOfFactoryKit
  {
    public override object CreateProduct(ProductCategory category)
    {
      switch (category)
      {
        case ProductCategory.ProductA:
          return new ConcreteProductA();
        case ProductCategory.ProductB:
          return new ConcreteProductB();
        default:
          throw new NotSupportedException();
      }
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
    public void TestCase3()
    {
      AbstractOrInterfaceOfFactoryKit kit = new ConcreteFactoryKit1();
      AbstractOrInterfaceOfProductA productA = (AbstractOrInterfaceOfProductA)kit.CreateProduct(ProductCategory.ProductA);
      AbstractOrInterfaceOfProductB productB = (AbstractOrInterfaceOfProductB)kit.CreateProduct(ProductCategory.ProductB);
    }
  }
}
