using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.Implementation3
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

  public class ConcreteDeepCopyPrototypeProductB
    : AbstractOrInterfaceOfPrototypeProduct
  {
    public ConcreteDeepCopyPrototypeProductB()
    {
      this.ReferenceProperty2 = new ReferencedClass() 
      { 
        ReferencedClassProperty1 = 222 
      };
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
    public void TestCase3()
    {
      AbstractOrInterfaceOfPrototypeProduct prototypeProduct1 = new ConcreteShallowCopyPrototypeProductA();
      AbstractOrInterfaceOfPrototypeProduct clonedProduct1 = prototypeProduct1.Clone();
      bool areEqual1 = object.ReferenceEquals(
        prototypeProduct1.ReferenceProperty2,
        clonedProduct1.ReferenceProperty2);

      AbstractOrInterfaceOfPrototypeProduct prototypeProduct2 = new ConcreteDeepCopyPrototypeProductB();
      AbstractOrInterfaceOfPrototypeProduct clonedProduct2 = prototypeProduct2.Clone();
      bool areEqual2 = object.ReferenceEquals(
        prototypeProduct2.ReferenceProperty2,
        clonedProduct2.ReferenceProperty2);

      Console.WriteLine("{0}, {1}", areEqual1, areEqual2);
    }
  }
}
