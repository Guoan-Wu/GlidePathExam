using AddorLib.Addor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddorLib.Output
{
    public class OutputToConsole : IOutput
    {
        private readonly string[] _header = {"| Previous value in file ","| User input value ",
            "| Calculations ","| New value in file " };
        private const string _border = "|";
        private const char _filling = '-';

        public void PrintHeader()
        {
            string l1 = "", l2 = "";
            foreach (var s in _header)
            {
                l1 += s;
                l2 += _border + new string(_filling, s.Length - 1);
            }
            l1 += _border;
            l2 += _border;
            Console.WriteLine(l1);
            Console.WriteLine(l2);
        }
        public void PrintNumber(IAddor data)
        {
            var fFormat = (string s, int index, bool last) =>
            {
                int len = _header[index].Length;
                string format = "{0,-" + len.ToString() + "}";
                string s2 = string.Format(format, _border + " " + s);
                if (last)
                {
                    s2 += _border;
                    Console.WriteLine(s2);
                }
                else
                {
                    Console.Write(s2);
                }
            };

            int index = 0;
            string s = data.PrevValue?.ToString() ?? "";
            fFormat(s, index, false); 
            index++;

            s = data.InputValue.ToString();
            fFormat(s, index, false); 
            index++;

            s = data.Act ?? "";
            fFormat(s, index, false); 
            index++;

            s = data.NewValue.ToString();
            fFormat(s, index, true); 
        }      
    }
}
