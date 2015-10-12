namespace FieldTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper;

    // TODO not well implemented, always pass!!!
    [TestClass]
    public class TestsIsCellClickled
    {
        private string[,] testMineFiled = new string[5, 10];
        private IField mineFieldTest = new Minesweeper.Field(5, 10, 15);

        [TestMethod]
        public void TestIfTheIsCellClickled()
        {
            this.mineFieldTest.GetDefaultField();
            this.testMineFiled[1, 1] = string.Empty;
            var output = this.mineFieldTest.IsCellClickled(1, 1);

            Assert.AreEqual(false, output);
        }

        [TestMethod]
        public void TestIfTheIsCellBoomed()
        {
            this.mineFieldTest.GetDefaultField();
            this.testMineFiled[1, 1] = "*";
            var output = this.mineFieldTest.IsCellClickled(1, 1);
            Assert.AreEqual(false, output);
        }

        [TestMethod]
        public void TestIfTheIsCellClickledNegative()
        {
            this.mineFieldTest.GetDefaultField();
            this.testMineFiled[1, 1] = " ";

            var output = this.mineFieldTest.IsCellClickled(4, 5);
            Assert.AreEqual(false, output);
        }

        [TestMethod]
        public void TestIfTheIsCellClickledNegativeWithNumber()
        {
            this.mineFieldTest.GetDefaultField();
            this.testMineFiled[1, 1] = "15";

            var output = this.mineFieldTest.IsCellClickled(1, 1);
            Assert.AreEqual(false, output);
        }
    }
}
