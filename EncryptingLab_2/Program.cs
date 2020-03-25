using System;
using EncryptingLab_2.Algorithms;

namespace EncryptingLab_2
{
    class Program
    {
        static void Main(string[] args)
        {
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

            //GasloviyCipher gaslo1 = new GasloviyCipher("Drozdov", "slogan");
            //Console.WriteLine("Гасло - slogan");
            //gaslo1.Print();
            //gaslo1.Encrypt();
            //gaslo1.Print();
            //gaslo1.Decrypt();
            //gaslo1.Print();

            //Console.WriteLine("Drozdov");
            //VijeneraCipher.Zavd();

            //PlayfairCipher playfair = new LatinPlayfair("Drozdov"); //TODO ПЕРЕДЕЛАТЬ ПОД POINT СТРУКТУРУ
            //playfair.Print();
            //Console.WriteLine("\n");
            //playfair.PrintAlphabet();
            //playfair.Encrypt();
            //Console.WriteLine("\n");
            //playfair.Print();

            VerticalCipher vertical = new VerticalCipher("DROZDOV ARTEM IUREVICH", "BITCOIN");
            vertical.Print();
            vertical.Shuffort();
            vertical.Encrypt();
            vertical.Print();
            vertical.Decrypt();
            vertical.Print();

            Console.ReadKey();
        }

    }


}