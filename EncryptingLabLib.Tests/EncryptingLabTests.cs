using System;
using EncryptingLab_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EncryptingLabLib.Tests
{
    [TestClass]
    public class EncryptingLabTests
    {
        [TestMethod]
        public void Sum_10and20_30return()
        {
            // arrange 
            int x = 10;
            int y = 20;
            int expected = 30;
            // act 

            ForTest c = new ForTest();
            int actual = c.Sum(x, y);
            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
