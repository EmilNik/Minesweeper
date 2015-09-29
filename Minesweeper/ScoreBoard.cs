namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class ScoreBoard : IScoreBoard
    {
        private OrderedMultiDictionary<int, string> scoreBoard;

        public ScoreBoard()
        {
            this.scoreBoard = new OrderedMultiDictionary<int, string>(true);
        }

        public void AddPlayer(string playerName, int playerScore)
        {
            if (!this.scoreBoard.ContainsKey(playerScore))
            {
                this.scoreBoard.Add(playerScore, playerName);
            }
            else
            {
                this.scoreBoard[playerScore].Add(playerName);
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
                var key = keys[i];
                var person = this.scoreBoard[key].ToArray()[0];

                Console.WriteLine("{0}. {1} --> {2} cells", (i + 1), person, key);

            }

            Console.WriteLine();
        }
    }
}
