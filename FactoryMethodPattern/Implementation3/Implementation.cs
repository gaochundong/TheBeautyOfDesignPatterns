using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern.Implementation3
{
  public enum ProductCategory
  {
    GoodProduct,
    BadProduct,
  }

  public class ConcreteCreator
  {
    public virtual AbstractOrInterfaceOfProduct CreateProduct(ProductCategory category)
    {
      switch (category)
      {
        case ProductCategory.GoodProduct:
          return new ConcreteGoodProduct();
        case ProductCategory.BadProduct:
          return new ConcreteBadProduct();
        default:
          throw new NotSupportedException();
      }
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
      ConcreteCreator creator = new ConcreteCreator();
      AbstractOrInterfaceOfProduct product = creator.CreateProduct(ProductCategory.GoodProduct);
    }
  }
}
