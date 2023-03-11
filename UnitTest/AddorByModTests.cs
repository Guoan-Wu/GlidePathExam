using AddorLib.Addor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class AddorByModTests
    {
        [Theory]
        [InlineData(null, 20, 20)]
        [InlineData(30, 122, 152)]
        [InlineData(132, 172, 152)]
        [InlineData(120, 31, 151)]
        [InlineData(99, 54, 1)]        
        public void Test_Add(int? prevValue, int inputValue, int expectedValue)
        {
            // Arrage
            IAddor obj = new AddorByMod();
            // Act
            int n = obj.Add(prevValue, inputValue);
            // Assert
            Assert.Equal(expectedValue, n);
        }
    }
}
