using System;
using System.Runtime.InteropServices;
using EncryptingLab_2.Algorithms;

namespace EncryptingLab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string main = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            int rows = 5, cols = 5;
            char[,] arr = new char[rows, cols];

            for (int i = 0, n = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++, n++)
                {
                    arr[i, j] = main[n];
                    Console.Write(arr[i, j] + "  ");
                }
                Console.WriteLine();
            }

            string input = "HI"; //KOZHUKHOVSKY
            ValueTuple<int, int> firstPos = (0, 0);
            ValueTuple<int, int> secondPos = (0, 0);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (arr[i, j].Equals(input[0]))
                    {
                        firstPos = (i, j);
                    }

                    else if (arr[i, j].Equals(input[1]))
                    {
                        secondPos = (i, j);
                    }
                }
            }

            Console.WriteLine("\n\n" + (arr[firstPos.Item1, firstPos.Item2], arr[secondPos.Item1, secondPos.Item2]));

            if (firstPos.Item1.Equals(secondPos.Item1))
            {
                int s = firstPos.Item2 + 1;
                if (s >= rows)
                {
                    s -= rows;
                }

                firstPos.Item2 = s;
            }
            else if (firstPos.Item2.Equals(secondPos.Item2))
            {
                int s = firstPos.Item1 + 1;
                if (s >= cols)
                {
                    s -= cols;
                }

                firstPos.Item1 = s;
            }


            if (secondPos.Item1.Equals(firstPos.Item1))
            {
                int s = secondPos.Item2 + 1;
                if (s >= rows)
                {
                    s -= rows;
                }

                secondPos.Item2 = s;
            }
            else if (secondPos.Item2.Equals(firstPos.Item2))
            {
                int s = secondPos.Item1 + 1;
                if (s >= cols)
                {
                    s -= cols;
                }

                secondPos.Item1 = s;
            }

            var res = (arr[firstPos.Item1, firstPos.Item2], arr[secondPos.Item1, secondPos.Item2]);
            Console.WriteLine("\n\n" + res);







            //VerticalCipher e1 = new VerticalCipher("KOZHUKHOVSKY YAROSLAV ALEKSANDROVICH", "FOREVER");
            //e1.Print();
            //e1.Shuffort();
            //e1.Encrypt();
            //e1.Print();
            //e1.Decrypt();
            //e1.Print();

            //VijeneraCipher.Zavd();

            //GasloviyCipher gaslo1 = new GasloviyShifr("Lulu", "slogan");
            //gaslo1.Encrypt();
            //gaslo1.Print();
            //gaslo1.Decrypt();
            //gaslo1.Print();

            //LatinOneLetter latSurname = new LatinOneLetter("Drozdov");
            //latSurname.Print();
            //latSurname.Encrypt();
            //latSurname.Print();
            //latSurname.Decrypt();
            //latSurname.Print();

            //CyrillicOneLetter cyrSurname = new CyrillicOneLetter("Дроздов");
            //cyrSurname.Print();
            //cyrSurname.Encrypt();
            //cyrSurname.Print();
            //cyrSurname.Decrypt();
            //cyrSurname.Print();

            Console.ReadKey();
        }

    }


}