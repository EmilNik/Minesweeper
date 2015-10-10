using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper;
using Minesweeper.Interfaces;

namespace Printer.Tests
{
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
            string emptySymbol = "";
            IField mineFieldTest = new Minesweeper.Field(row, call, mines);
            mineFieldTest.GetDefaultField();


            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < call; j++)
                {
                    testMineFiled[i, j] = "";
                    Assert.AreEqual(emptySymbol, testMineFiled[i, j]);
                }
            }
        }

        [TestMethod]
        public void TaetPrintScoreBoard()
        {/*
             var numberOfPrintedNames = 10;
            IDataManager fileManager = new Minesweeper.TextFileDataManager();
            ScoreBoard scoreBoard = new Minesweeper.ScoreBoard(fileManager);
            var items = from pair in scoreBoard.Scores
                        orderby pair.Value descending
                        select pair;

            var keys = items.ToArray();
            
            var Scores = fileManager.Read();

            string[,] testMineFiled = new string[row, call];
            string emptySymbol = "";
            IField mineFieldTest = new Minesweeper.Field(row, call, mines);
            mineFieldTest.GetDefaultField();


            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < call; j++)
                {
                    testMineFiled[i, j] = "";
                    Assert.AreEqual(emptySymbol, testMineFiled[i, j]);
                }
            }
        }
        public void PrintScoreBoard()
        {
           
            

            if (keys.Count() < numberOfPrintedNames)
            {
                numberOfPrintedNames = keys.Count();
            }

            for (int i = 0; i < numberOfPrintedNames; i++)
            {
                var person = keys[i].Key;
                var key = keys[i].Value;

                var message = "{i+1}. {person} --> {key} cell";

                if (key != 1)
                {
                    message += "s";
                }

                Console.WriteLine(message);
            }

            Console.WriteLine();
        }*/

        }
    }
}
