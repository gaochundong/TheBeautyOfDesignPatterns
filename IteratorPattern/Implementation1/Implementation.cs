using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.Implementation1
{
  public abstract class Iterator
  {
    public abstract object First();
    public abstract object MoveNext();
    public abstract object Current();
    public abstract bool IsDone();
    public abstract void Reset();
  }

  public abstract class Aggregate
  {
    public abstract Iterator CreateIterator();
  }

  public class ConcreteAggregate : Aggregate
  {
    private readonly ArrayList _items = new ArrayList();

    public int Count
    {
      get { return _items.Count; }
    }

    public object this[int index]
    {
      get { return _items[index]; }
      set { _items.Insert(index, value); }
    }

    public override Iterator CreateIterator()
    {
      return new ConcreteIterator(this);
    }
  }

  public class ConcreteIterator : Iterator
  {
    private readonly ConcreteAggregate _aggregate;
    private int _currentIndex = 0;

    public ConcreteIterator(ConcreteAggregate aggregate)
    {
      _aggregate = aggregate;
    }

    public override object First()
    {
      if (_aggregate.Count > 0)
        return _aggregate[0];
      else
        return null;
    }

    public override object MoveNext()
    {
      object item = null;
      if (_currentIndex < _aggregate.Count - 1)
      {
        item = _aggregate[++_currentIndex];
      }

      return item;
    }

    public override object Current()
    {
      return _aggregate[_currentIndex];
    }

    public override bool IsDone()
    {
      return _currentIndex >= _aggregate.Count;
    }

    public override void Reset()
    {
      _currentIndex = 0;
    }
  }

  public class Client
  {
    public void TestCase1()
    {
      var aggregate = new ConcreteAggregate();
      aggregate[0] = "Apple";
      aggregate[1] = "Orange";
      aggregate[2] = "Strawberry";

      var iterator = new ConcreteIterator(aggregate);

      object item = iterator.First();
      while (!iterator.IsDone())
      {
        Console.WriteLine(item);
        item = iterator.MoveNext();
      }
    }
  }
}
