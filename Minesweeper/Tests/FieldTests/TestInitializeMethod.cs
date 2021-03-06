﻿namespace FieldTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper;

    [TestClass]
    public class TestInitializeMethod
    {
        [TestMethod]
        public void TestNumberOfMines()
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

        [TestMethod]
        public void TestSymbolsWithoutMines()
        {
            Field mineFieldTest = new Minesweeper.Field(5, 10, 15);
            mineFieldTest.Initialize();
            Cell[,] testMineFiled = mineFieldTest.MineField;

            string expectedstarSymbol = string.Empty;
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

            Assert.AreEqual(35, counter);
        }

        [TestMethod]
        public void TestNegativeEmprySymbol()
        {
            Field mineFieldTest = new Minesweeper.Field(5, 10, 15);
            mineFieldTest.Initialize();
            Cell[,] testMineFiled = mineFieldTest.MineField;

            string expectedEmptySymbol = string.Empty;
            string expectedstarSymbol = "*";
            int counter = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((testMineFiled[i, j].Value != expectedstarSymbol) && 
                        (testMineFiled[i, j].Value != expectedEmptySymbol))                
                    {
                        counter++;
                    }
                }
            }

            Assert.AreEqual(0, counter);
        }
    }
}
