using System;

namespace EncryptingLab_2.Algorithms
{
    class PlayfairCipher : IEncrypt
    {
        protected ValueTuple<int, int> alphabetDimensionRowsCols;
        protected string alphabet;
        protected char[,] alphabetMatrix;
        public string EncryptedMessage { get; set; }

        public string MainString { get; set; }

        protected PlayfairCipher(string input)
        {
            MainString = input.ToUpper();
        }

        public void Encrypt()
        {
            if (MainString.Length % 2 != 0)
            {
                MainString += "X";
            }
            for (int startIndex = 0, gramNum = 2; startIndex < MainString.Length; startIndex += gramNum)
            {
                var item = MainString.Substring(startIndex, gramNum);

                ValueTuple<int, int> firstPos = (0, 0);
                ValueTuple<int, int> secondPos = (0, 0);

                if (item[0] == 'J')
                {
                    item = "I" + item[1];
                }
                else if (item[1] == 'J')
                {
                    item = item[0] + "I";
                }

                for (int i = 0; i < alphabetDimensionRowsCols.Item1; i++)
                {
                    for (int j = 0; j < alphabetDimensionRowsCols.Item2; j++)
                    {
                        if (alphabetMatrix[i, j] == item[0])
                        {
                            firstPos = (i, j);
                        }

                        if (alphabetMatrix[i, j] == item[1])
                        {
                            secondPos = (i, j);
                        }
                    }
                }

                Crypt(ref firstPos, ref secondPos);

                EncryptedMessage += String.Concat(alphabetMatrix[firstPos.Item1, firstPos.Item2], 
                                        alphabetMatrix[secondPos.Item1, secondPos.Item2]);
            }

            MainString = EncryptedMessage;
        }

        private void Crypt(ref ValueTuple<int, int> firstPosition, ref ValueTuple<int, int> secondPosition)
        {
            if (firstPosition == secondPosition)
            {
                secondPosition = (4, 2);
            }

            if (firstPosition.Item1 == secondPosition.Item1)
            {
                int s = firstPosition.Item2 + 1;
                if (s >= alphabetDimensionRowsCols.Item1)
                {
                    s -= alphabetDimensionRowsCols.Item1;
                }

                firstPosition.Item2 = s;
            }
            else if (firstPosition.Item2 == secondPosition.Item2)
            {
                int s = firstPosition.Item1 + 1;
                if (s >= alphabetDimensionRowsCols.Item2)
                {
                    s -= alphabetDimensionRowsCols.Item2;
                }

                firstPosition.Item1 = s;
            }


            if (secondPosition.Item1 == firstPosition.Item1)
            {
                int s = secondPosition.Item2 + 1;
                if (s >= alphabetDimensionRowsCols.Item1)
                {
                    s -= alphabetDimensionRowsCols.Item1;
                }

                secondPosition.Item2 = s;
            }
            else if (secondPosition.Item2 == firstPosition.Item2)
            {
                int s = secondPosition.Item1 + 1;
                if (s >= alphabetDimensionRowsCols.Item2)
                {
                    s -= alphabetDimensionRowsCols.Item2;
                }

                secondPosition.Item1 = s;
            }

            else
            {
                int temp = firstPosition.Item2;
                firstPosition.Item2 = secondPosition.Item2;
                secondPosition.Item2 = temp;
            }
        }

        public void Decrypt()
        {
            throw new NotImplementedException();
        }

        protected void Fill()
        {
            for (int i = 0, n = 0; i < alphabetDimensionRowsCols.Item1; i++)
            {
                for (int j = 0; j < alphabetDimensionRowsCols.Item2; j++, n++)
                {
                    alphabetMatrix[i, j] = alphabet[n];
                }
            }
        }

        public void Print()
        {
            Console.WriteLine(MainString);
        }

        public void PrintLetter(int firstIndex, int secondIndex)
        {
            Console.Write(alphabetMatrix[firstIndex, secondIndex]);
        }

        public void PrintAlphabet()
        {
            for (int i = 0; i < alphabetDimensionRowsCols.Item1; i++)
            {
                for (int j = 0; j < alphabetDimensionRowsCols.Item2; j++)
                {
                    Console.Write(alphabetMatrix[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
    }

    class LatinPlayfair : PlayfairCipher
    {
        public LatinPlayfair(string input) : base(input)
        {
            alphabetDimensionRowsCols = (5, 5);
            alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            alphabetMatrix = new char[alphabetDimensionRowsCols.Item1, alphabetDimensionRowsCols.Item2];
            Fill();
        }
    }
}
