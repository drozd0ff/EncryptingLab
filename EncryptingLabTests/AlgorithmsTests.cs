using EncryptingLab_2;
using EncryptingLab_2.Algorithms;
using NUnit.Framework;

namespace EncryptingLabTests
{
    [TestFixture]
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
           
        //}

        [TestCase("Drozdov", "slogan", "GQKZGKV")]
        [TestCase("Kozhukhovsky", "slogan", "FKZCUFCKVRFY")]
        public void GasloviyEncryptTest(string input, string key, string expected)
        {
            GasloviyCipher gasloviy = new GasloviyCipher(input, key);
            gasloviy.Encrypt();
            Assert.AreEqual(expected, gasloviy.MainString);
        }


        [TestCase("Drozdov", "BTPYITWY")]
        [TestCase("Kozhukhovsky", "IPXKZPINXQIZ")]
        public void PlayfairEncryptTest(string input, string expected)
        {
            PlayfairCipher playfair = new LatinPlayfair(input);
            playfair.Encrypt();
            Assert.AreEqual(expected, playfair.MainString);
        }


        [TestCase("Drozdov", "Artem", "DIHDPOM")]
        [TestCase("Kozhukhovsky", "bitcoin", "LWSJISUPDLMM")]
        public void VijeneraEncryptTest(string input, string key, string expected)
        {
            VijeneraCipher vijenera = new VijeneraCipher(input, key);
            vijenera.Encrypt();
            Assert.AreEqual(expected, vijenera.MainString);
        }


        [TestCase("Drozdov Artem IUrevich", "bitcoin", "DAR ZEI RRE OIH VU DMC OTV")]
        [TestCase("Kozhukhovsky Yaroslav Aleksandrovich", "forever", "HKLSI KYVNH KORLR OVOEO ZSSKV HAAD UYAAC")]
        public void VerticalEncryptTest(string input, string key, string expected)
        {
            VerticalCipher vertical = new VerticalCipher(input, key);
            vertical.Encrypt();
            Assert.AreEqual(expected, vertical.MainString);
        }

        [TestCase("DAR ZEI RRE OIH VU DMC OTV", "bitcoin", "DROZDOVARTEMIUREVICH")]
        [TestCase("HKLSI KYVNH KORLR OVOEO ZSSKV HAAD UYAAC", "forever", "KOZHUKHOVSKYYAROSLAVALEKSANDROVICH")]
        public void VerticalDecryptTest(string input, string key, string expected)
        {
            VerticalCipher vertical = new VerticalCipher(expected, key);
            vertical.Encrypt();
            vertical.Decrypt();
            Assert.AreEqual(expected, vertical.MainString);
        }
    }
}