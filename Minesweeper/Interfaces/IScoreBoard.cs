namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IScoreBoard
    {
        void AddPlayer(string playerName, int playerScore);
    }
}
