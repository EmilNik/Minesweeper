namespace Minesweeper
{
    using System.Collections.Generic;

    public interface IScoreBoard
    {
        Dictionary<string, int> Scores { get; set; }

        void AddPlayer(string playerName, int playerScore);
    }
}
