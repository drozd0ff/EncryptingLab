using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EncryptingLab_2
{
    class VijeneraCipher : IEncrypt
    {
        private static readonly char[] latinAlphabet = Enumerable.Range(0, 26).Select(x => Convert.ToChar(65 + x)).ToArray();
        private string Key { get; }
        public string MainString { get; set; }
        public VijeneraCipher(string input, string key)
        {
            while (input.Length > key.Length)
            {
                for (int i = 0; i < key.Length; i++)
                {
                    key += key[i];
                    if (input.Length <= key.Length)
                    {
                        break;
                    }
                }
            }
        }

        public void Encrypt()
        {
            int[] inputNumbers = MainString.ToUpper().Select(x => x - 'A').ToArray();
            //List<int> inputNumbers = new List<int>(MainString.ToUpper().Select(x => x - 'A'));
            //List<int> keyNumbers = new List<int>(Key.ToUpper().Select(x => x - 'A'));
            int[] keyNumbers = Key.ToUpper().Select(x => x - 'A').ToArray();
            //List<int> encryptedMessageNumbers = new List<int>();
            int[] encryptedMessageNumbers = new int[inputNumbers.Length];

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                int item = inputNumbers[i] + keyNumbers[i];
                if (item >= 26)
                {
                    item %= 26;
                }
                //encryptedMessageNumbers.Add(item);
                encryptedMessageNumbers[i] = item;
            }

            MainString = String.Concat(encryptedMessageNumbers.Select(x => latinAlphabet[x]));
        }

        public static void Zavd()
        {
            

            //MainString = String.Empty;

            //foreach (var item in res3)
            //{
            //    mainString += latinAlphabet[item];
            //}

            //Console.WriteLine(mainString);
        }

        public void Decrypt()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            Console.WriteLine(MainString);
        }
    }
}
