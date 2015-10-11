namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    using Interfaces;
    using Wintellect.PowerCollections;

    /// <summary>
    /// The ScoreBoard that holds a list of all player and their scores.
    /// </summary>
    public class ScoreBoard : IScoreBoard
    {
        private readonly IDataManager fileManager;

        /// <summary>
        /// A dictionary to store all the hghscores and player names in.
        /// </summary>
        private Dictionary<string, int> scores;

        public ScoreBoard(IDataManager fileManager)
        {
            this.fileManager = fileManager;
            this.Scores = fileManager.Read();
        }

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
