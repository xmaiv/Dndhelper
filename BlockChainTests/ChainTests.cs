
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlockChain.Tests
{
    [TestClass()]
    public class ChainTests
    {
        [TestMethod()]
        public void ChainTest()
        {
            var chain = new Chain();
            chain.Add("bla bla bla", "Vlad");

            Assert.AreEqual(chain.Last.Data, "bla bla bla");
            Assert.AreEqual(chain.Last.User, "Vlad");
        }

        [TestMethod()]
        public void CheckTest()
        {
            var chain = new Chain();
            chain.Add("bla", "Michael");
            chain.Add("bla bla", "Alex");
            chain.Add("bla bla bla", "Tom");

            Assert.IsTrue(chain.Check());
        }
    }
}