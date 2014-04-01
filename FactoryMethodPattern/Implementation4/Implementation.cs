using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern.Implementation4
{
  public abstract class AbstractOrInterfaceOfCreator
  {
    public abstract AbstractOrInterfaceOfProduct CreateProduct();
  }

  public class GenericConcreteCreator<T> : AbstractOrInterfaceOfCreator
    where T : AbstractOrInterfaceOfProduct, new()
  {
    public override AbstractOrInterfaceOfProduct CreateProduct()
    {
      return new T();
    }
  }

  public abstract class AbstractOrInterfaceOfProduct
  {
  }

  public class ConcreteGoodProduct : AbstractOrInterfaceOfProduct
  {
  }

  public class ConcreteBadProduct : AbstractOrInterfaceOfProduct
  {
  }

  public partial class Test
  {
    public void Case3()
    {
      AbstractOrInterfaceOfCreator creator1 = new GenericConcreteCreator<ConcreteGoodProduct>();
      AbstractOrInterfaceOfCreator creator2 = new GenericConcreteCreator<ConcreteBadProduct>();
      AbstractOrInterfaceOfProduct product1 = creator1.CreateProduct();
      AbstractOrInterfaceOfProduct product2 = creator2.CreateProduct();
    }
  }
}
