using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddorLib
{
    /// <summary>
    /// Interface for input. E.g., inputting from console.
    /// </summary>
    public interface IInput
    {
        int? GetNumber();
    }
}
