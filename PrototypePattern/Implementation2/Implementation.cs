using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.Implementation2
{
  public class ReferencedClass
  {
    public int ReferencedClassProperty1 { get; set; }
  }

  public abstract class AbstractOrInterfaceOfPrototypeProduct
  {
    public int ValueProperty1 { get; set; }
    public ReferencedClass ReferenceProperty2 { get; set; }

    public abstract AbstractOrInterfaceOfPrototypeProduct Clone();
  }

  public class ConcreteShallowCopyPrototypeProductA
    : AbstractOrInterfaceOfPrototypeProduct
  {
    public ConcreteShallowCopyPrototypeProductA()
    {
      this.ReferenceProperty2 = new ReferencedClass()
      {
        ReferencedClassProperty1 = 111
      };
    }

    public override AbstractOrInterfaceOfPrototypeProduct Clone()
    {
      return new ConcreteShallowCopyPrototypeProductA()
      {
        ValueProperty1 = this.ValueProperty1,
        ReferenceProperty2 = this.ReferenceProperty2,
      };
    }
  }

  public class Client
  {
    public void TestCase2()
    {
      AbstractOrInterfaceOfPrototypeProduct prototypeProduct1 = new ConcreteShallowCopyPrototypeProductA();
      AbstractOrInterfaceOfPrototypeProduct clonedProduct1 = prototypeProduct1.Clone();
      bool areEqual1 = object.ReferenceEquals(
        prototypeProduct1.ReferenceProperty2, 
        clonedProduct1.ReferenceProperty2);
    }
  }
}
