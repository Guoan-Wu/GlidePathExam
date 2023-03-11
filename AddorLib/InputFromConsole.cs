using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddorLib
{
    public class InputFromConsole : IInput
    {
        public int? GetNumber()
        {
            Console.WriteLine("Please input a number: ");
            var s = Console.ReadLine();
            int v = 0;
            return int.TryParse(s, out v) ? v : null;
        }
    }
}
