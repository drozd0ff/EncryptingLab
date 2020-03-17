using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptingLab_2.Algorithms
{
    class VerticalShift : IEncrypt
    {
        public string MainString { get; set; }
        private double[] key;
        private List<double> secondList;
        SortedDictionary<double, string> dic;
        public VerticalShift(string main, string keyWord)
        {
            if (keyWord.Length >= 100)
            {
                throw new Exception("key word is too long, please make it less than 100 characters");
            }
            string[] mainStringArray = main.Split((char[]) null, StringSplitOptions.RemoveEmptyEntries);
            MainString = String.Join("", mainStringArray);
            dic = new SortedDictionary<double, string>();
            key = keyWord.Select(x => (double)x).ToArray();
        }

        public void Encrypt()
        {
            for (int i = 0; i < secondList.Count; i++)
            {
                for (int j = 0; j < MainString.Length; j += secondList.Count)
                {
                    var item = i + j;
                    if (item >= MainString.Length)
                    {
                        break;
                    }

                    if (dic.ContainsKey(secondList[i]))
                    {
                        dic[secondList[i]] += MainString.Substring(item, 1);
                    }
                    else
                    {
                        dic.Add(secondList[i], MainString.Substring(item, 1));
                    }
                }
            }

            IEnumerator<double> s = dic.Keys.GetEnumerator();
            MainString = String.Empty;
            while (s.MoveNext())
            {
                MainString += dic[s.Current] + " ";
            }
            s.Dispose();
        }

        public void Shuffort()
        {
            secondList = new List<double>();

            double j = 0;
            for (int i = 0; i < key.Length; i++, j += 0.01)
            {
                double item = key[i];
                key[i] = 0;
                if (secondList.Contains(item))
                {
                    item += j;
                    secondList.Add(item);
                }
                else
                {
                    secondList.Add(item);
                }
            }
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
