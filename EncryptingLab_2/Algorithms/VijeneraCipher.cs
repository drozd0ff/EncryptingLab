﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptingLab_2
{
    static class VijeneraCipher
    {
        public static void Zavd()
        {
            var alphabet = new List<char>(Enumerable.Range(0, 26).Select(x => Convert.ToChar(65 + x)).ToArray());
            alphabet.Add('_');
            //var mainString = "KOZHUKHOVSKY";
            var mainString = "Drozdov";
            //var key = "BITCOIN";
            var key = "lalalend";
            while (key.Length < mainString.Length)
            {
                key += key;
            }

            var res = new List<int>(mainString.ToUpper().Select(x => x - 'A'));
            var res2 = new List<int>(key.ToUpper().Select(x => x - 'A'));
            var res3 = new List<int>();

            for (int i = 0; i < res.Count(); i++)
            {
                var item = res[i] + res2[i];
                if (item >= 27)
                {
                    item %= 27;
                }
                res3.Add(item);
            }

            mainString = String.Empty;

            foreach (var item in res3)
            {
                mainString += alphabet[item];
            }

            Console.WriteLine(mainString);
        }
    }
}
