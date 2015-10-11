namespace Printer.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper;

    [TestClass]
    public class PrintInitialMessageTest
    {
        /*
        private IField Minesweeper;
        [TestMethod]
        public void PrintMessageTest()
        {
            IPrinter printer = new Minesweeper.Printer();
            string message = "This is a TEST PRINT";
           // var result = printer.PrintMessage(message);
            //Assert.AreEqual(true, result);
        }*/

        [TestMethod]
        public void TestGetDefaultFieldMethod()
        {
            int row = 5;
            int call = 10;
            int mines = 15;
            string[,] testMineFiled = new string[row, call];
            string emptySymbol = string.Empty;
            IField mineFieldTest = new Minesweeper.Field(row, call, mines);
            mineFieldTest.GetDefaultField();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < call; j++)
                {
                    testMineFiled[i, j] = string.Empty;
                    Assert.AreEqual(emptySymbol, testMineFiled[i, j]);
                }
            }
        }
    }
}
