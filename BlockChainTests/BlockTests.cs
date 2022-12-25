
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlockChain.Tests
{
    [TestClass()]
    public class BlockTests
    {
        [TestMethod()]
        public void SerializeTest()
        {
            var block = new Block();
            var result = block.Serialize();
            var expected = "{\"Created\":\"\\/Date(1585861200000)\\/\",\"Data\":\"Hello world\",\"Hash\":\"210ae57cbaa1d9dd13894d36969c4407d50bdc5e8181b2f1197a6a6b3abd1eab\",\"PreviousHash\":\"111111\",\"User\":\"Admin\"}";

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void DeserializeTest()
        {
            var json = "{\"Created\":\"\\/Date(1585861200000)\\/\",\"Data\":\"Hello world\",\"Hash\":\"210ae57cbaa1d9dd13894d36969c4407d50bdc5e8181b2f1197a6a6b3abd1eab\",\"PreviousHash\":\"111111\",\"User\":\"Admin\"}";

            var expected = new Block();
            var result   = expected.Serialize();
            Block actual = Block.Deserialize(result);

            //Assert.AreEqual(expected.Data, actual.Data);
            Assert.AreEqual(expected.Created, actual.Created);
            Assert.AreEqual(expected.Hash, actual.Hash);
            Assert.AreEqual(expected.PreviousHash, actual.PreviousHash);
            Assert.AreEqual(expected.User, actual.User);
        }
    }
}