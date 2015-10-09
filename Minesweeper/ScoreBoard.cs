namespace Minesweeper
{
    using Interfaces;
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
        private Dictionary<string, int> scores;

        public Dictionary<string, int> Scores
        {
            get
            {
                return this.scores;
            }
            private set
            {
                this.scores = value;
            }
        }

        private readonly IDataManager fileManager;
        
        public ScoreBoard(IDataManager fileManager)
        {
            this.fileManager = fileManager;

            this.Scores = fileManager.Read();
        }

        /// <summary>
        /// Adds a new player to the Score board. Accepts playerName and playerScore that are saved in the database.
        /// </summary>
        /// <param name="playerName">The name of the player.</param>
        /// <param name="playerScore">The score of the player.</param>
        public void AddPlayer(string playerName, int playerScore)
        {
            if (!this.Scores.ContainsKey(playerName))
            {
                this.Scores.Add(playerName, playerScore);
            }
            else
            {
                if (this.Scores[playerName] < playerScore)
                {
                    this.Scores[playerName] = playerScore;
                }
            }
            this.fileManager.Write(this.Scores);

            this.Scores = this.fileManager.Read();
        }
    }
}
