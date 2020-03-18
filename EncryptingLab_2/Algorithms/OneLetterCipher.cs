using System;
using System.Collections.Generic;
using System.Linq;

namespace EncryptingLab_2
{
    class OneLetterCipher : IEncrypt //TODO Вынести алфавиты в общие какие то поля, их наследовать
    {
        private int lettersCount;
        protected List<int> keys;
        protected char[] alphabet;

        public string AlphabetName { get; private set; }

        public string MainString { get; set; }

        public int LettersCount
        {
            get => lettersCount;
            set
            {
                try
                {
                    switch (value)
                    {
                        case 26:
                            lettersCount = value;
                            AlphabetName = "Latin";
                            break;
                        case 32:
                            lettersCount = value;
                            AlphabetName = "Cyrillic";
                            break;
                        default:
                            throw new Exception("Nonexistent alphabet");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public OneLetterCipher(string main)
        {
            keys = new List<int>();
            MainString = main;
        }

        protected IEnumerable<int> numerableLetters;
        public virtual void Encrypt()
        {
            List<int> mySurnameNotEncrypted = new List<int>();
            List<int> mySurnameEncrypted = new List<int>();

            foreach (int item in numerableLetters)
            {
                mySurnameNotEncrypted.Add(item);
            }

            foreach (int item in mySurnameNotEncrypted)
            {
                mySurnameEncrypted.Add(keys[item]);
            }

            MainString = String.Empty;
            foreach (int item in mySurnameEncrypted)
            {
                MainString += alphabet[item];
            }
        }

        public void Decrypt()
        {
            List<char> mainStringChars = new List<char>();
            mainStringChars.AddRange(MainString.ToUpper().ToCharArray());

            MainString = String.Empty;
            foreach (char item in mainStringChars)
            {
                int temp = Array.IndexOf(alphabet, item);
                temp = keys.IndexOf(temp);
                MainString += alphabet[temp];
            }
        }

        public void Print()
        {
            Console.WriteLine(MainString);
        }            
    }

    class LatinOneLetter : OneLetterCipher
    {
        public LatinOneLetter(string main) : base(main)
        {
            LettersCount = 26;
            keys.Fill(LettersCount);
            keys.Shuffle();
            alphabet = Enumerable.Range(0, LettersCount).Select(x => Convert.ToChar(65 + x)).ToArray(); //65 - dec latin 'A'
        }

        public override void Encrypt()
        {
            numerableLetters = MainString.ToUpper().Select(x => x - 'A');
            base.Encrypt();
        }
    }

    class CyrillicOneLetter : OneLetterCipher
    {
        public CyrillicOneLetter(string main) : base(main)
        {
            LettersCount = 32;
            keys.Fill(LettersCount);
            keys.Shuffle();
            alphabet = Enumerable.Range(0, LettersCount).Select(x => Convert.ToChar(1040 + x)).ToArray(); // 1040 - dec cyrillic 'A'
        }

        public override void Encrypt()
        {
            numerableLetters = MainString.ToUpper().Select(x => x - 'А');
            base.Encrypt();
        }
    }

    static class ListExtensions
    {
        private static Random rnd = new Random();

        public static void Shuffle<T>(this List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static void Fill(this List<int> list, int n)
        {
            for (int i = 0; i < n; i++)
            {
                list.Add(i);
            }
        }
    }
}
