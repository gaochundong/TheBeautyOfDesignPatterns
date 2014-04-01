using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Implementation1
{
  public abstract class Strategy
  {
    public abstract void AlgorithmInterface(string state);
  }

  public class ConcreteStrategyA : Strategy
  {
    public override void AlgorithmInterface(string state)
    {
      Console.WriteLine("Use Concrete Strategy A to handle " + state);
    }
  }

  public class ConcreteStrategyB : Strategy
  {
    public override void AlgorithmInterface(string state)
    {
      Console.WriteLine("Use Concrete Strategy B to handle " + state);
    }
  }

  public class Context
  {
    private Strategy _strategy;

    public void SetStrategy(Strategy strategy)
    {
      _strategy = strategy;
    }

    public string State { get; set; }

    public void ContextInterface()
    {
      _strategy.AlgorithmInterface(State);
    }
  }

  public class Client
  {
    public void TestCase1()
    {
      var context = new Context();
      context.State = "Hello World";

      context.SetStrategy(new ConcreteStrategyA());
      context.ContextInterface();

      context.SetStrategy(new ConcreteStrategyB());
      context.ContextInterface();
    }
  }
}
