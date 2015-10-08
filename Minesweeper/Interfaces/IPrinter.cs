using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public interface IPrinter
    {
        void PrintMessageWithNewLine(string message);

        void PrintScoreBoard();

        void PrintField(string[,] minesMatrix, bool boomed);

        void PrintMessage(string message);

        void PrintMessage(string message, int openedCells);
    }
}
