using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var Inspector = new Inspector();
            while (true)
            {
                Console.Write("Введите выражение: ");
                var expr = Console.ReadLine();
                if(Inspector.isInspector(expr)==true)
                    continue;
            }
        }
    }
}
