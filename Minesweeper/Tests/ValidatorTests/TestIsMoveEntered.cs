namespace ValidatorTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper;

    [TestClass]
    public class TestsIsMoveEntered
    {
        [TestMethod]
        public void TestIsMoveEnteredValid()
        {
            Validator validator = new Validator();
            var output = validator.IsMoveEntered("5 6");
            Assert.AreEqual(true, output);
        }

        /*
         A little bit unuseles - there is another Validator for Range - Are we using it? 
         
        [TestMethod]
        public void TestIsMoveEnteredValidZero()
        {
            Validator validator = new Validator();
            var output = validator.IsMoveEntered("0 6");
            Assert.AreEqual(true, output);
        }

        [TestMethod]
        public void TestIsMoveEnteredValidZeroZero()
        {
            Validator validator = new Validator();
            var output = validator.IsMoveEntered("0 0");
            Assert.AreEqual(true, output);
        }

        [TestMethod]
        public void TestIsMoveEnteredValidZeroNine()
        {
            Validator validator = new Validator();
            var output = validator.IsMoveEntered("0 9");
            Assert.AreEqual(true, output);
        }

        [TestMethod]
        public void TestIsMoveEnteredValidNineNine()
        {
            Validator validator = new Validator();
            var output = validator.IsMoveEntered("0 9");
            Assert.AreEqual(true, output);
        }*/

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIsMoveEnteredNotValidOneParameter()
        {
            Validator validator = new Validator();
            validator.IsMoveEntered("5");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestIsMoveEnteredNotValidStringAsParameter()
        {
            Validator validator = new Validator();
            validator.IsMoveEntered("name something");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIsMoveEnteredNotValidNegativParameters()
        {
            Validator validator = new Validator();
            validator.IsMoveEntered("-1 5");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestIsMoveEnteredNotValid()
        {
            Validator validator = new Validator();
            validator.IsMoveEntered("5, 6");
        }
    }
}
