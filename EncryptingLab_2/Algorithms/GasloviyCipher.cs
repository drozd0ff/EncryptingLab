using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptingLab_2
{
    class GasloviyCipher : IEncrypt
    {
        private char[] key; // s l o g a n _ B C D E etc.
        private char[] alphabet;
        private List<char> result;

        public GasloviyCipher(string input, string inputGaslo)
        {
            alphabet = Enumerable.Range(0, 26).Select(x => Convert.ToChar(65 + x)).ToArray();
            key = inputGaslo.ToUpper().ToCharArray(); // s l o g a n _
            MainString = input.ToUpper(); //Drozdov
            result = new List<char>(key);
            IEnumerable<char> arr3 = alphabet.Except(key);
            result.AddRange(arr3);
        }

        public string MainString { get; set; } //Drozdov

        public void Encrypt()
        {
            string notEncryptedMainString = MainString;
            MainString = String.Empty;
            foreach (var item in notEncryptedMainString)
            {
                MainString += result[Array.IndexOf(alphabet, item)];
            }
        }

        public void Decrypt()
        {
            string EncryptedMainString = MainString;
            MainString = String.Empty;
            foreach (var VARIABLE in EncryptedMainString)
            {
                MainString += alphabet[result.IndexOf(VARIABLE)];
            }
        }

        public void Print()
        {
            Console.WriteLine(MainString);
        }
    }
}
