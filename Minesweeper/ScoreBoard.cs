namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class ScoreBoard : IScoreBoard
    {
        public readonly Dictionary<string, int> scoreBoard;

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
    }
}
