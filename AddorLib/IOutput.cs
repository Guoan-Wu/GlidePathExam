using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddorLib
{
    public interface IOutput
    {
        void PrintHeader();
        void PrintNumber(IAddor data);
    }
}
