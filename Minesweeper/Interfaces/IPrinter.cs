using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public interface IPrinter
    {
        void PrintScoreBoard(ScoreBoard scoreBoard);

        void PrintField(string[,] minesMatrix, bool boomed);

        void PrintMessage(string message);
    }
}
