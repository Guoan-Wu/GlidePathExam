using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddorLib.NumberContainer
{
    /// <summary>
    /// Interface of containers for reading/writing number.
    /// </summary>
    public interface INumberContainer
    {
        Task<int?> ReadNumberAsync();
        Task WriteNumberAsync(int n);

    }
}

