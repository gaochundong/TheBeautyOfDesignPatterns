using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
  class Program
  {
    static void Main(string[] args)
    {
      Implementation3.Client client = new Implementation3.Client();
      client.TestCase3();

      Console.ReadKey();
    }
  }
}
