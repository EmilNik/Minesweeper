namespace FieldTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper;

    [TestClass]
    public class TestFillWithRandomMines
    {
        [TestMethod]
        public void FillWithRandomMinesCountedMines()
        {
            Field mineFieldTest = new Minesweeper.Field(5, 10, 15);
            mineFieldTest.Initialize();
            Cell[,] testMineFiled = mineFieldTest.MineField;

            string expectedstarSymbol = "*";
            int counter = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (testMineFiled[i, j].Value == expectedstarSymbol)
                    {
                        counter++;
                    }
                }
            }

            Assert.AreEqual(15, counter);
        }
    }
}
