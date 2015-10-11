using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper;

namespace FieldTests
{
    //TO DO not well implemented, always pass!!!
    [TestClass]
    public class TestsIsCellClickled
    {
            string[,] testMineFiled = new string[5, 10];
            IField mineFieldTest = new Minesweeper.Field(5, 10, 15);
            

        [TestMethod]
        public void TestIfTheIsCellClickled()
        {
            mineFieldTest.GetDefaultField();
            testMineFiled[1, 1] = "";
            var output = mineFieldTest.IsCellClickled(1,1);

            Assert.AreEqual(false, output);
        }

        [TestMethod]
        public void TestIfTheIsCellBoomed()
        {
            mineFieldTest.GetDefaultField();
            testMineFiled[1,1] = "*"; 
            var output = mineFieldTest.IsCellClickled(1,1);
            Assert.AreEqual(false, output);
        }

        [TestMethod]
        public void TestIfTheIsCellClickledNegative()
        {
            mineFieldTest.GetDefaultField();
            testMineFiled[1, 1] = " ";

            var output = mineFieldTest.IsCellClickled(4,5);
            Assert.AreEqual(false, output);
        }

        [TestMethod]
        public void TestIfTheIsCellClickledNegativeWithNumber()
        {
            mineFieldTest.GetDefaultField();
            testMineFiled[1, 1] = "15";

            var output = mineFieldTest.IsCellClickled(1, 1);
            Assert.AreEqual(false, output);
        }

    }
}
