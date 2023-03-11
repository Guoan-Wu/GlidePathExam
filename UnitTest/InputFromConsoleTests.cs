using AddorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [Collection("NonConcurrentTests")]
    public class InputFromConsoleTests
    {
        [Theory]
        [InlineData("999", 999)]
        [InlineData("+100", 100)]
        [InlineData("0", 0)]
        [InlineData("-1", -1)]
        [InlineData("world", null)]
        [InlineData(".", null)]
        [InlineData("+", null)]
        [InlineData("-", null)]
        public void TestGetNumber(string input, int? expectedValue)
        {
            // Arrage
            var prevOut = Console.Out;
            IInput obj = new InputFromConsole();
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader(input))
                {
                    var prevIn = Console.In;
                    Console.SetIn(sr);
                    // Act
                    var n = obj.GetNumber();
                    Console.SetIn(prevIn);
                    Console.SetOut(prevOut);
                    // Assert
                    Assert.Equal(expectedValue, n);
                }
            }
        }
    }
}