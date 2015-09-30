namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class ScoreBoard : IScoreBoard
    {
        private Dictionary<string, int> scoreBoard;

        public ScoreBoard()
        {
            this.scoreBoard = new Dictionary<string, int>();
        }

        public void AddPlayer(string playerName, int playerScore)
        {
            if (!this.scoreBoard.ContainsKey(playerName))
            {
                this.scoreBoard.Add(playerName, playerScore);
            }
            else
            {
                if (this.scoreBoard[playerName] < playerScore)
                {
                    this.scoreBoard[playerName] = playerScore;
                }
            }
        }

        public void PrintScoreBoard()
        {
            var numberOfPrintedNames = 5;
            var keys = this.scoreBoard.Keys.OrderByDescending(obj => obj).ToArray();

            if (keys.Length < numberOfPrintedNames)
            {
                numberOfPrintedNames = keys.Length;
            }

            for (int i = 0; i < numberOfPrintedNames; i++)
            {
                var person = keys[i];
                var key = this.scoreBoard[person];

                Console.WriteLine("{0}. {1} --> {2} cells", (i + 1), person, key);

            }

            Console.WriteLine();
        }
    }
}
