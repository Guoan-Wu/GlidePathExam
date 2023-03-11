using AddorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class NumberFileTests
    {
        [Theory]
        [InlineData("./testdata.txt", null)]
        [InlineData("./testdata.txt", 5)]
        [InlineData("./testdata.txt", -1)]
        [InlineData("./testdata.txt", +99)]
        public async Task TestReadNumber_Valid(string filePath, int? expectedValue)
        {
            // Arrage                       
            await File.WriteAllTextAsync(filePath, expectedValue?.ToString());

            NumberFile obj = new NumberFile(filePath);
            // Act
            var n = await obj.ReadNumberAsync();
            // Assert
            Assert.Equal(expectedValue, n);
        }
        [Fact]
        public async Task TestReadNumber_InvaidMultiNumbers()
        {
            // Arrage
            string filePath = "./testdata.txt";
            string s = "12 455";
            await File.WriteAllTextAsync(filePath, s);

            NumberFile obj = new NumberFile(filePath);
            // Act
            try
            {
                var n = await obj.ReadNumberAsync();
            }
            catch (ArgumentException ex)
            {
                // Assert
                bool ok = ex.ToString().StartsWith("Errors in");
                Assert.True(ok);
            }
        }
        [Fact]
        public async Task TestReadNumber_NoExistedFile()
        {
            // Arrage            
            Random random = new Random();
            string filePath = "";
            do
            {
                filePath = "./" + random.Next().ToString() + ".txt";
            } while (File.Exists(filePath));

            NumberFile obj = new NumberFile(filePath);
            int? expectedValue = null;
            // Act
            var n = await obj.ReadNumberAsync();
            // Assert
            Assert.Equal(expectedValue, n);
        }
        [Theory]
        [InlineData("./testdata.txt", 5)]
        [InlineData("./testdata.txt", -1)]
        [InlineData("./testdata.txt", +99)]
        public async Task TestWriteNumber(string filePath, int expectedValue)
        {
            // Arrage
            NumberFile obj = new NumberFile(filePath);
            // Act
            await obj.WriteNumberAsync(expectedValue);
            // Assert
            var arr = File.ReadAllLines(filePath);
            Assert.True(arr.Length == 1 && int.Parse(arr[0]) == expectedValue);
        }
    }
}

