namespace Minesweeper
{
    using System;

    public interface IPrinter
    {
        void PrintMessageWithNewLine(string message);

        void PrintScoreBoard();

        void PrintField(Cell[,] minesMatrix, bool boomed);

        void PrintMessage(string message);

        void PrintMessage(string message, int openedCells);
    }
}
