using System;
using System.Linq;

namespace EncryptingLab_2
{
    public class VijeneraCipher : IEncrypt
    {
        private static readonly char[] latinAlphabet = Enumerable.Range(0, 26).Select(x => Convert.ToChar(65 + x)).ToArray();
        private string Key { get; }
        public string MainString { get; set; }
        public VijeneraCipher(string input, string key)
        {
            MainString = input.ToUpper();
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

            key = key.ToUpper();
            Key = key;
        }

        public void Encrypt()
        {
            int[] inputNumbers = MainString.ToUpper().Select(x => x - 'A').ToArray();
            int[] keyNumbers = Key.ToUpper().Select(x => x - 'A').ToArray();

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
