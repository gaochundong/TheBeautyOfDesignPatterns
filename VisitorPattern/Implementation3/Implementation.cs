using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisitorPattern.Implementation3
{
  public abstract class Employee
  {
    public abstract string Accept(EmployeeVisitor visitor);
  }

  public class HourlyEmployee : Employee
  {
    public override string Accept(EmployeeVisitor visitor)
    {
      try
      {
        IHourlyEmployeeVisitor hourlyEmployeeVisitor = (IHourlyEmployeeVisitor)visitor;
        return hourlyEmployeeVisitor.Visit(this);
      }
      catch (InvalidCastException ex)
      {
        Console.WriteLine(ex.Message);
      }

      return string.Empty;
    }
  }

  public class SalariedEmployee : Employee
  {
    public override string Accept(EmployeeVisitor visitor)
    {
      try
      {
        ISalariedEmployeeVisitor salariedEmployeeVisitor = (ISalariedEmployeeVisitor)visitor;
        return salariedEmployeeVisitor.Visit(this);
      }
      catch (InvalidCastException ex)
      {
        Console.WriteLine(ex.Message);
      }

      return string.Empty;
    }
  }

  public interface IHourlyEmployeeVisitor
  {
    string Visit(HourlyEmployee employee);
  }

  public interface ISalariedEmployeeVisitor
  {
    string Visit(SalariedEmployee employee);
  }

  public abstract class EmployeeVisitor
  {
  }

  public class HoursPayReport : EmployeeVisitor, IHourlyEmployeeVisitor
  {
    public string Visit(HourlyEmployee employee)
    {
      // generate the line of the report.
      return "100 Hours and $1000 in total.";
    }
  }

  public class SalariedPayReport : EmployeeVisitor, ISalariedEmployeeVisitor
  {
    public string Visit(SalariedEmployee employee)
    {
      return "Something";
    }
  }
}
