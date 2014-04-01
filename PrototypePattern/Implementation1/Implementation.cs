using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.Implementation1
{
  public abstract class AbstractOrInterfaceOfPrototypeProduct
  {
    public int ValueProperty1 { get; set; }

    public abstract AbstractOrInterfaceOfPrototypeProduct Clone();
  }

  public class ConcretePrototypeProductA : AbstractOrInterfaceOfPrototypeProduct
  {
    public override AbstractOrInterfaceOfPrototypeProduct Clone()
    {
      return new ConcretePrototypeProductA()
      {
        ValueProperty1 = this.ValueProperty1,
      };
    }
  }

  public class ConcretePrototypeProductB : AbstractOrInterfaceOfPrototypeProduct
  {
    public override AbstractOrInterfaceOfPrototypeProduct Clone()
    {
      return new ConcretePrototypeProductB()
      {
        ValueProperty1 = this.ValueProperty1,
      };
    }
  }

  public class ProductPrototypeManager
  {
    private Dictionary<string, AbstractOrInterfaceOfPrototypeProduct> _registry
      = new Dictionary<string, AbstractOrInterfaceOfPrototypeProduct>();

    public void Register(string name,
      AbstractOrInterfaceOfPrototypeProduct prototypeProduct)
    {
      _registry[name] = prototypeProduct;
    }

    public void Unregister(string name)
    {
      _registry.Remove(name);
    }

    public AbstractOrInterfaceOfPrototypeProduct Retrieve(string name)
    {
      return _registry[name];
    }

    public bool IsRegisterd(string name)
    {
      return _registry.ContainsKey(name);
    }
  }

  public class Client
  {
    public void TestCase1()
    {
      AbstractOrInterfaceOfPrototypeProduct prototypeProduct1 = new ConcretePrototypeProductA();
      AbstractOrInterfaceOfPrototypeProduct prototypeProduct2 = new ConcretePrototypeProductB();

      ProductPrototypeManager manager = new ProductPrototypeManager();
      manager.Register("PrototypeProduct1", prototypeProduct1);
      manager.Register("PrototypeProduct2", prototypeProduct2);

      AbstractOrInterfaceOfPrototypeProduct clonedProduct1 = manager.Retrieve("PrototypeProduct1").Clone();

      if (manager.IsRegisterd("PrototypeProduct2"))
      {
        AbstractOrInterfaceOfPrototypeProduct clonedProduct2 = manager.Retrieve("PrototypeProduct2").Clone();
      }
    }
  }
}
