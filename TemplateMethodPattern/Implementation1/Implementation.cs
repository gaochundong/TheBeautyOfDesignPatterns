using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern.Implementation1
{
  public abstract class Algorithm
  {
    public void TemplateMethod()
    {
      Step1CanNotBeCustomized();
      Step2();
      Step3WithDefault();
    }

    private void Step1CanNotBeCustomized()
    {
      Console.WriteLine("Step1");
    }

    protected abstract void Step2();

    protected virtual void Step3WithDefault()
    {
      Console.WriteLine("Default Step3");
    }
  }

  public class ConcreteAlgorithmA : Algorithm
  {
    protected override void Step2()
    {
      Console.WriteLine("ConcreteAlgorithmA.Step2");
    }
  }

  public class ConcreteAlgorithmB : Algorithm
  {
    protected override void Step2()
    {
      Console.WriteLine("ConcreteAlgorithmB.Step2");
    }

    protected override void Step3WithDefault()
    {
      Console.WriteLine("ConcreteAlgorithmB.Step3");
    }
  }

  public class Program
  {
    public void TestCase1()
    {
      var algorithm1 = new ConcreteAlgorithmA();
      algorithm1.TemplateMethod();

      var algorithm2 = new ConcreteAlgorithmB();
      algorithm2.TemplateMethod();
    }
  }
}
