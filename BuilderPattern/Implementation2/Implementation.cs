using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.Implementation2
{
  public class ComplexProduct
  {
    public string ValueDependOnWeather { get; set; }
    public string ValueDependOnFortune { get; set; }
  }

  public abstract class AbstractComplexProductBuilder
  {
    protected ComplexProduct _complexProduct;

    public void BeginBuild(ComplexProduct existingComplexProduct = null)
    {
      if (existingComplexProduct == null)
        _complexProduct = new ComplexProduct();
      else
        _complexProduct = existingComplexProduct;
    }

    public virtual string BuildValueDependOnWeatherPart(string weather)
    {
      // could do nothing by default
      _complexProduct.ValueDependOnWeather = weather;
      return _complexProduct.ValueDependOnWeather;
    }

    public virtual string BuildValueDependOnFortunePart(string luck, string combinedWithWeather)
    {
      // could do nothing by default
      _complexProduct.ValueDependOnFortune = luck + combinedWithWeather;
      return _complexProduct.ValueDependOnFortune;
    }

    public ComplexProduct EndBuild()
    {
      return this._complexProduct;
    }
  }

  public class ConcreteProductBuilderA : AbstractComplexProductBuilder
  {
    private string _dayOfWeek;
    private int _luckyNumber;

    public ConcreteProductBuilderA(string dayOfWeek, int luckyNumber)
    {
      _dayOfWeek = dayOfWeek;
      _luckyNumber = luckyNumber;
    }

    public override string BuildValueDependOnWeatherPart(string weather)
    {
      // something customized
      _complexProduct.ValueDependOnWeather = _dayOfWeek + " is " + weather;
      return _complexProduct.ValueDependOnWeather;
    }

    public override string BuildValueDependOnFortunePart(string luck, string combinedWithWeather)
    {
      // something customized
      if (_luckyNumber == 8)
        _complexProduct.ValueDependOnFortune = "Supper" + luck + combinedWithWeather;
      else
        _complexProduct.ValueDependOnFortune = "Just so so" + luck + combinedWithWeather;
      return _complexProduct.ValueDependOnFortune;
    }
  }

  public class GoodWeatherAndGoodLuckDirector
  {
    public void ConstructWithGoodWeatherAndGoodLuck(AbstractComplexProductBuilder builder)
    {
      string weather = builder.BuildValueDependOnWeatherPart(@"PM2.5 < 50");
      builder.BuildValueDependOnFortunePart(@"Good Luck", weather);
    }

    public void ConstructWithBadWeatherAndBadLuck(AbstractComplexProductBuilder builder)
    {
      string weather = builder.BuildValueDependOnWeatherPart(@"PM2.5 > 500");
      builder.BuildValueDependOnFortunePart(@"Bad Luck", weather);
    }
  }

  public class Client
  {
    public void TestCase2()
    {
      AbstractComplexProductBuilder builder = new ConcreteProductBuilderA("Sunday", 9);
      GoodWeatherAndGoodLuckDirector director = new GoodWeatherAndGoodLuckDirector();

      builder.BeginBuild();
      director.ConstructWithGoodWeatherAndGoodLuck(builder);
      ComplexProduct productWithGoodLuck = builder.EndBuild();

      builder.BeginBuild();
      director.ConstructWithBadWeatherAndBadLuck(builder);
      ComplexProduct productWithBadLuck = builder.EndBuild();
    }
  }
}
