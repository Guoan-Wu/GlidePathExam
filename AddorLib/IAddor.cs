using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddorLib
{
    public interface IAddor
    {
        int MaxValue { get; set; }
        int? PrevValue { get; set; }
        int InputValue { get; set; }
        int NewValue { get; set; }
        string? Act { get; set; }
        int Add(int? prevValue, int inputValue);

    }
}
