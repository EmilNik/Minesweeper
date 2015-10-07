namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    /// <summary>
    /// The ScoreBoard that holds a list of all player and their scores.
    /// </summary>
    public class ScoreBoard : IScoreBoard
    {

        /// <summary>
        /// A dictionary to store all the hghscores and player names in.
        /// </summary>
        public readonly Dictionary<string, int> scoreBoard;

        public ScoreBoard()
        {
            this.scoreBoard = new Dictionary<string, int>();
        }

        /// <summary>
        /// Adds a new player to the Score board. Accepts playerName and playerScore that are saved in the database.
        /// </summary>
        /// <param name="playerName">The name of the player.</param>
        /// <param name="playerScore">The score of the player.</param>
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
