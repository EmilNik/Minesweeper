namespace MinesweeperEngineTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper;

    [TestClass]
    public class TestsIsPlayerGrandWinner
    {
        [TestMethod]
        public void TestIsPlayerGrandWinner()
        {
            MinesweeperEngine testGame = new MinesweeperEngine();
            Cell[,] matrix = new Cell[5, 10];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    matrix[i, j].Value = "3";
                }

                matrix[i, 9].Value = "*";
            }

            var result = testGame.IsPlayerGrandWinner(matrix, 5);
            Assert.AreEqual(true, result);
            /*
            Field mineFieldTest = new Minesweeper.Field(5, 10, 5);
            //mineFieldTest.Initialize();
            Cell [,] testMineFiled = mineFieldTest.MineField;

          
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    testMineFiled[i, j].Value = "4";
                    //testMineFiled[i, j].isFlagged = true;
                }
                //testMineFiled[i, 9].isBomb = true;
                testMineFiled[i, 9].Value = "*";
            }

            var result = testGame.IsPlayerGrandWinner(testMineFiled, 5);
            Assert.AreEqual(true, result);*/
        }
    }
}
