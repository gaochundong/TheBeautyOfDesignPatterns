using InterpreterPattern.Implementation1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterPattern
{
  class Program
  {
    static void Main(string[] args)
    {
      var client = new Client();
      client.TestCase1();

      Console.ReadKey();
    }
  }
}
