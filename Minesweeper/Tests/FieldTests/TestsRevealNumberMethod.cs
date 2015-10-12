namespace FieldTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper;

     /// <summary>
    /// TEst the correctness of the reveal number
    /// </summary>
    [TestClass]
    public class TestsRevealNumberMethod
    {
        [TestMethod]
        public void TestRevealNumber()
        {  
            // Create a Test Field
            int testRow = 5;
            int testCall = 10;
            int mines = 15;
            string[,] testMineFiled = new string[testRow, testCall];

            IField mineFieldTest = new Minesweeper.Field(testRow, testCall, mines);

            mineFieldTest.GetDefaultField();

            int minesCounter = 0;
            while (minesCounter < 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    testMineFiled[0, i] += "*";
                    minesCounter++;
                }
            }

            int revialedCells = 0;
            string expectedRevealNumber = "2";

            mineFieldTest.RevialCell(1, 0);

            if (testMineFiled[1, 0] == string.Empty)
            {
                int[] directionRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
                int[] directionCol = { 1, 0, -1, -1, -1, 0, 1, 1 };
                int minesCounterRevealNumber = 0;

                for (int direction = 0; direction < 8; direction++)
                {
                    int newRow = directionRow[direction] + 1;
                    int newCol = directionCol[direction] + 0;
                    if (mineFieldTest.IsMoveInBounds(newRow, newCol))
                    {
                        if (testMineFiled[newRow, newCol] == "*")
                        {
                            minesCounterRevealNumber++;
                        }
                    }
                }

                testMineFiled[1, 0] = Convert.ToString(minesCounterRevealNumber);
                string result = testMineFiled[1, 0];
                revialedCells++;
                Assert.AreEqual(expectedRevealNumber, result);
            }
        }

        [TestMethod]
        public void TestRevealNumberWithEightBombs()
        { 
            // Create a Test Field
            int testRow = 5;
            int testCall = 10;
            int mines = 15;
            string[,] testMineFiled = new string[testRow, testCall];

            IField mineFieldTest = new Minesweeper.Field(testRow, testCall, mines);

            mineFieldTest.GetDefaultField();

            // bombs All Around            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    testMineFiled[i, j] += "*";
                }
            }

            testMineFiled[1, 1] += string.Empty;

            int revialedCells = 0;
            string expectedRevealNumber = "8";

            mineFieldTest.RevialCell(1, 1);

            if (testMineFiled[1, 1] == string.Empty)
            {
                int[] directionRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
                int[] directionCol = { 1, 0, -1, -1, -1, 0, 1, 1 };
                int minesCounterRevealNumber = 0;

                for (int direction = 0; direction < 8; direction++)
                {
                    int newRow = directionRow[direction] + 1;
                    int newCol = directionCol[direction] + 0;
                    if (mineFieldTest.IsMoveInBounds(newRow, newCol))
                    {
                        if (testMineFiled[newRow, newCol] == "*")
                        {
                            minesCounterRevealNumber++;
                        }
                    }
                }

                testMineFiled[1, 0] = Convert.ToString(minesCounterRevealNumber);
                string result = testMineFiled[1, 0];
                revialedCells++;
                Assert.AreEqual(expectedRevealNumber, result);
            }
        }
    }
}
