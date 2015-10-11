﻿


namespace FieldTests
{   using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper;   

     [TestClass]
    public class TestsGetDefaultFieldMethod
    {
        [TestMethod]
        public void TestGetDefaultFieldMethod()
        {
            int row = 5;
            int call = 10;
            int mines = 15;
            string[,] testMineFiled = new string[row, call];
            string emptySymbol = "";
            IField mineFieldTest = new Minesweeper.Field(row, call, mines);
            mineFieldTest.GetDefaultField();


            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < call; j++)
                {
                    testMineFiled[i, j] = "";
                    Assert.AreEqual(emptySymbol, testMineFiled[i,j]);
                }
            }
            
        }

        [TestMethod]
        public void TestGetDefaultFieldMethodNegative()
        {
            int row = 5;
            int call = 10;
            int mines = 15;
            string[,] testMineFiled = new string[row, call];
            string emptySymbol = " ";
            IField mineFieldTest = new Minesweeper.Field(row, call, mines);
            mineFieldTest.GetDefaultField();


            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < call; j++)
                {
                    testMineFiled[i, j] = "";
                    Assert.AreNotEqual(emptySymbol, testMineFiled[i, j]);
                }
            }
        }
    }
}

