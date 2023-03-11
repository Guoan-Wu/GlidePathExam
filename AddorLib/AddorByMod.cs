using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddorLib
{
    public class AddorByMod : IAddor
    {
        public int MaxValue { get; set; }
        public int? PrevValue { get; set; }
        public int InputValue { get; set; }
        public int NewValue { get; set; }
        public string? Act { get; set; }
        public AddorByMod(int maxValue = 152)
        {
            MaxValue = maxValue;
        }

        public int Add(int? prevValue, int inputValue)
        {
            var fAct = (bool doSub) => {
                string s = "";
                if (InputValue > 0) s += "+";
                else if (InputValue < 0) s += "-";
                s += InputValue.ToString();
                if (doSub)
                    s += (", -" + MaxValue.ToString());
                return s;
            };
            PrevValue = prevValue;
            InputValue = inputValue;

            int newValue = (int)(PrevValue ?? 0) + InputValue;
            if (MaxValue != 0 && newValue > MaxValue)
            {
                newValue %= MaxValue;
                if (newValue == 0)
                {
                    newValue = MaxValue;
                }
                Act = fAct(true);
            }
            else
            {
                Act = fAct(false);
            }
            NewValue = newValue;
            return NewValue;
        }
    }
}

