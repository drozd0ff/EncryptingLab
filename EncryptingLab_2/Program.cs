﻿using System;
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

            GasloviyCipher gasloviy = new GasloviyCipher("Drozdov", "slogan");
            gasloviy.Print();
            gasloviy.Encrypt();
            gasloviy.Print();
            gasloviy.Decrypt();
            gasloviy.Print();

            //VijeneraCipher vijenera = new VijeneraCipher("DROZDOV", "ARTEM");
            //vijenera.Encrypt();
            //vijenera.Print();

            //PlayfairCipher playfair = new LatinPlayfair("Drozdov");
            //playfair.PrintAlphabet();
            //playfair.Print();
            //playfair.Encrypt();
            //playfair.Print();

            //VerticalCipher vertical = new VerticalCipher("Drozdov Artem IUrevich", "Bitcoin");
            //vertical.Print();
            //vertical.Encrypt();
            //vertical.Print();
            //vertical.Decrypt();
            //vertical.Print();


            Console.ReadKey();
        }
    }
}