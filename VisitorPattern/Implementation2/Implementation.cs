using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisitorPattern.Implementation2
{
  public abstract class Employee
  {
    public abstract string Accept(EmployeeVisitor visitor);
  }

  public class HourlyEmployee : Employee
  {
    public override string Accept(EmployeeVisitor visitor)
    {
      return visitor.Visit(this);
    }
  }

  public class SalariedEmployee : Employee
  {
    public override string Accept(EmployeeVisitor visitor)
    {
      return visitor.Visit(this);
    }
  }

  public abstract class EmployeeVisitor
  {
    public abstract string Visit(HourlyEmployee employee);
    public abstract string Visit(SalariedEmployee employee);
  }

  public class HoursPayReport : EmployeeVisitor
  {
    public override string Visit(HourlyEmployee employee)
    {
      // generate the line of the report.
      return "100 Hours and $1000 in total.";
    }

    public override string Visit(SalariedEmployee employee)
    {
      // do nothing
      return string.Empty;
    }
  }
}
