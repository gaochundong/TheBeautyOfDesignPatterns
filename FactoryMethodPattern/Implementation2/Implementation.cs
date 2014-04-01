using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern.Implementation2
{
  public class ConcreteCreator
  {
    public virtual AbstractOrInterfaceOfProduct CreateProduct()
    {
      return new ConcreteProduct();
    }
  }

  public abstract class AbstractOrInterfaceOfProduct
  {
  }

  public class ConcreteProduct : AbstractOrInterfaceOfProduct
  {
  }

  public partial class Test
  {
    public void Case2()
    {
      ConcreteCreator creator = new ConcreteCreator();
      AbstractOrInterfaceOfProduct product = creator.CreateProduct();
    }
  }
}
