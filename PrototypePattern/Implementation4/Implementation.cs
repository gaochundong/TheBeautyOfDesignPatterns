using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.Implementation4
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

  public class ConcreteDeepCopyPrototypeProductB
    : AbstractOrInterfaceOfPrototypeProduct
  {
    public ConcreteDeepCopyPrototypeProductB()
    {
    }

    public void Initialize(int propertyValue)
    {
      this.ValueProperty1 = propertyValue;
      this.ReferenceProperty2.ReferencedClassProperty1 = propertyValue;
    }

    public override AbstractOrInterfaceOfPrototypeProduct Clone()
    {
      return new ConcreteDeepCopyPrototypeProductB()
      {
        ValueProperty1 = this.ValueProperty1,
        ReferenceProperty2 = new ReferencedClass()
        {
          ReferencedClassProperty1 =
            this.ReferenceProperty2.ReferencedClassProperty1
        },
      };
    }
  }

  public class Client
  {
    public void TestCase4()
    {
      AbstractOrInterfaceOfPrototypeProduct prototypeProduct2 = new ConcreteDeepCopyPrototypeProductB();
      ConcreteDeepCopyPrototypeProductB clonedProduct2 = 
        (ConcreteDeepCopyPrototypeProductB)prototypeProduct2.Clone();

      clonedProduct2.Initialize(123);
    }
  }
}
