using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddorLib.Addor;
using AddorLib.Input;
using AddorLib.NumberContainer;
using AddorLib.Output;

namespace AddorLib
{
    public class AddorAppFactory
    {
        public static AddorApp CreateInstance()
        {

            IInput input = new InputFromConsole();
            IAddor addor = new AddorByMod();
            NumberFile numberFile = new("./data.txt");
            IOutput output = new OutputToConsole();
            return new AddorApp(input, numberFile, addor, output);
        }
    }
}

