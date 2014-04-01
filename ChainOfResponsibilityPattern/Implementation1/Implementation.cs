using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityPattern.Implementation1
{
  public enum RequestCategory
  {
    Category1,
    Category2,
  }

  public abstract class Request
  {
    public abstract RequestCategory Category { get; }
    public bool IsHandled { get; set; }
  }

  public class ConcreteRequest1 : Request
  {
    public override RequestCategory Category
    {
      get { return RequestCategory.Category1; }
    }
  }

  public class ConcreteRequest2 : Request
  {
    public override RequestCategory Category
    {
      get { return RequestCategory.Category2; }
    }
  }

  public abstract class Handler
  {
    private Handler _successor;

    public Handler()
    {
    }

    public Handler(Handler successor)
    {
      _successor = successor;
    }

    public void Handle(Request request)
    {
      OnHandle(request);

      if (!request.IsHandled)
      {
        if (_successor != null)
        {
          // pass request to successor
          _successor.Handle(request);
        }
      }
    }

    protected abstract void OnHandle(Request request);
  }

  public class ConcreteHandler1 : Handler
  {
    public ConcreteHandler1()
    {
    }

    public ConcreteHandler1(Handler successor)
      : base(successor)
    {
    }

    protected override void OnHandle(Request request)
    {
      if (request.Category == RequestCategory.Category1)
      {
        // handle the request which category is Category1
        request.IsHandled = true;
      }
    }
  }

  public class ConcreteHandler2 : Handler
  {
    public ConcreteHandler2()
    {
    }

    public ConcreteHandler2(Handler successor)
      : base(successor)
    {
    }

    protected override void OnHandle(Request request)
    {
      if (request.Category == RequestCategory.Category2)
      {
        // handle the request which category is Category2
        request.IsHandled = true;
      }
    }
  }

  public class Client
  {
    public void TestCase1()
    {
      Request request1 = new ConcreteRequest1();
      Request request2 = new ConcreteRequest2();

      Handler handler2 = new ConcreteHandler2();
      Handler handler1 = new ConcreteHandler1(handler2);

      handler1.Handle(request1);
      handler1.Handle(request2);
    }
  }
}
