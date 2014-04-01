using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern.Implementation1
{
  public abstract class AbstractOrInterfaceOfCreator
  {
    public abstract AbstractOrInterfaceOfProduct CreateProduct();
  }

  public abstract class AbstractOrInterfaceOfProduct
  {
  }

  public class ConcreteCreator : AbstractOrInterfaceOfCreator
  {
    public override AbstractOrInterfaceOfProduct CreateProduct()
    {
      return new ConcreteProduct();
    }
  }

  public class ConcreteProduct : AbstractOrInterfaceOfProduct
  {
  }

  public partial class Test
  {
    public void Case1()
    {
      AbstractOrInterfaceOfCreator creator = new ConcreteCreator();
      AbstractOrInterfaceOfProduct product = creator.CreateProduct();
    }
  }
}
