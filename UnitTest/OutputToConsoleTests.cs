using AddorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [Collection("NonConcurrentTests")]
    public class OutputToConsoleTests
    {
        [Fact]
        public void TestPrintHeader()
        {
            // Arrange
            string expectedValue = "| Previous value in file | User input value | Calculations | New value in file |\r\n";
            expectedValue += "|------------------------|------------------|--------------|-------------------|\r\n";
            IOutput output = new OutputToConsole();
            //Act

            //Assert
            using (var sw = new StringWriter())
            {
                var current = Console.Out;
                Console.SetOut(sw);
                // Act
                output.PrintHeader();

                // Assert
                string s = sw.ToString();
                Assert.Equal(expectedValue, s);
                Console.SetOut(current);
            }
        }
        [Theory]
        [InlineData(null, 3, "|                        | 3                | +3           | 3                 |\r\n")]
        [InlineData(30, 122, "| 30                     | 122              | +122         | 152               |\r\n")]
        [InlineData(132, 172, "| 132                    | 172              | +172, -152   | 152               |\r\n")]
        public void TestPrintNumber(int? prevValue, int inputValue, string expectedValue)
        {
            // Arrange
            IAddor addor = new AddorByMod();
            int result = addor.Add(prevValue, inputValue);
            IOutput output = new OutputToConsole();

            using (var sw = new StringWriter())
            {
                var current = Console.Out;
                Console.SetOut(sw);
                // Act
                output.PrintNumber(addor);
                string s = sw.ToString();
                Console.SetOut(current);

                // Assert
                Assert.Equal(expectedValue, s);
            }
        }
    }
}

