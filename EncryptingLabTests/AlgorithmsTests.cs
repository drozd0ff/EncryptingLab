using EncryptingLab_2;
using EncryptingLab_2.Algorithms;
using NUnit.Framework;

namespace EncryptingLabTests
{
    [TestFixture]
    public class Tests
    {
        private const string mySurname = "Drozdov";
        private const string myName = "Artem";

        private const string kozhukhovsky = "Kozhukhovsky";
        private const string bitcoin = "bitcoin";

        //[SetUp]
        //public void Setup()
        //{
           
        //}

        [TestCase(mySurname, myName, "DIHDPOM")]
        [TestCase(kozhukhovsky, bitcoin, "LWSJISUPDLMM")]
        public void VijeneraEncryptTest(string input, string key, string expected)
        {
            VijeneraCipher vijenera = new VijeneraCipher(input, key);
            vijenera.Encrypt();
            Assert.AreEqual(expected, vijenera.MainString);
        }

        [TestCase("Drozdov Artem IUrevich", bitcoin, "DAR ZEI RRE OIH VU DMC OTV")]
        [TestCase("Kozhukhovsky Yaroslav Aleksandrovich", "forever", "HKLSI KYVNH KORLR OVOEO ZSSKV HAAD UYAAC")]
        public void VerticalEncryptTest(string input, string key, string expected)
        {
            VerticalCipher vertical = new VerticalCipher(input, key);
            vertical.Encrypt();
            Assert.AreEqual(expected, vertical.MainString);
        }

        public void VerticalDecryptTest()
    }
}