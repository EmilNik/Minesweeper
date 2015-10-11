namespace ValidatorTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper;

    [TestClass]
    public class TestCheckIfIntIsInRange
    {
        [TestMethod]
        [ExpectedException(typeof( ArgumentOutOfRangeException))]
        public void TestCheckIfIntIsInRangeFiveBetweenSixEndTen()
        {
            Validator validator = new Validator();
            validator.CheckIfIntIsInRange("Number", 5, 6, 10);

        }

        [TestMethod]
        [ExpectedException(typeof( ArgumentOutOfRangeException))]
        public void TestCheckIfIntIsInRangeElevenBetweenSixEndTen()
        {
            Validator validator = new Validator();
            validator.CheckIfIntIsInRange("Number", 11, 6, 10);
        }

        [TestMethod]
        public void TestCheckIfIntIsInRangeSixbBetweenSixEndTen()
        {
            Validator validator = new Validator();
            var result = validator.CheckIfIntIsInRange("Number", 6, 6, 10);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestCheckIfIntIsInRangeElevenBetweenSixEndTenSecond()
        {
            Validator validator = new Validator();
            var result = validator.CheckIfIntIsInRange("Number", 11, 6, 10);
            Assert.AreNotEqual(true, result);
        }
       
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCheckIfIntIsInRangeMinusOne2bBetweenSixEndTen()
        {
            Validator validator = new Validator();
            validator.CheckIfIntIsInRange("Name", -1, 6, 10);
        }
    }
}
