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
    public class AddorApp
    {
        private IInput Input { get; set; }
        private INumberContainer NumberContainer { get; set; }
        private IAddor Addor { get; set; }
        private IOutput Output { get; set; }
        public AddorApp(IInput input, INumberContainer numberContainer,
            IAddor addor, IOutput output)
        {
            Input = input;
            NumberContainer = numberContainer;
            Addor = addor;
            Output = output;
        }
        public async Task Run()
        {
            while (true)
            {
                try
                {
                    var prevValue = NumberContainer.ReadNumberAsync();
                    int? n = Input.GetNumber();
                    await prevValue;

                    if (n is null) continue;

                    int result = Addor.Add(prevValue.Result, (int)n);
                    var taskWrite = NumberContainer.WriteNumberAsync(result);

                    Output.PrintHeader();
                    Output.PrintNumber(Addor);

                    await taskWrite;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return;
                }

            }

        }
    }
}

