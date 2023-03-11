using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddorLib
{
    public class NumberFile : INumberContainer
    {
        string? FilePath { get; set; }
        public NumberFile(string filePath)
        {
            FilePath = filePath;
        }
        /// <summary>
        /// Read the number from the file FilePath.
        /// </summary>
        /// <returns>return value is (empty?, value).</returns>
        /// <exception cref="ArgumentNullException" >Throw when FilePath is null.</exception>
        /// <exception cref="ArgumentException" >Throw when number's count is more than 1.</exception>
        public async Task<int?> ReadNumberAsync()
        {
            if (FilePath == null)
                throw new ArgumentNullException(nameof(FilePath));

            if (!File.Exists(FilePath))
                return null;
            var s = await File.ReadAllLinesAsync(FilePath);
            if (s.Length == 0)
            {
                return null;
            }
            if (s.Length != 1)
                throw new ArgumentException("Error in {0}! The number's count must be 0 or 1.", nameof(ReadNumberAsync));            
            
            int n = 0;
            return int.TryParse(s[0], out n) ? n : null;
        }

        /// <summary>
        /// Write the number into the file FilePath.
        /// </summary>
        /// <param name="n"> The number to write.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Throw the exception when FilePath == null.</exception>
        public async Task WriteNumberAsync(int n)
        {
            if (FilePath == null)
                throw new ArgumentNullException(nameof(FilePath));

            await File.WriteAllTextAsync(FilePath, n.ToString());
        }
    }
}
