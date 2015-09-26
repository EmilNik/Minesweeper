using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class Printer : IPrinter
    {
        public void PrintScoreBoard(IScoreBoard scoreBoard)
        {
        }

        public void PrintField(string[,] minesMatrix, bool boomed)
        {
            Console.WriteLine();
            Console.WriteLine("     0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < minesMatrix.GetLength(0); i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < minesMatrix.GetLength(1); j++)
                {
                    if (!(boomed) && ((minesMatrix[i, j] == "") || (minesMatrix[i, j] == "*")))
                    {
                        Console.Write(" ?");
                    }
                    if (!(boomed) && (minesMatrix[i, j] != "") && (minesMatrix[i, j] != "*"))
                    {
                        Console.Write(" {0}", minesMatrix[i, j]);
                    }
                    if ((boomed) && (minesMatrix[i, j] == ""))
                    {
                        Console.Write(" -");
                    }
                    if ((boomed) && (minesMatrix[i, j] != ""))
                    {
                        Console.Write(" {0}", minesMatrix[i, j]);
                    }

                }
                Console.WriteLine("|");
            }
            Console.WriteLine("   ---------------------");
        }

        public void PrintInitialMessage()
        {
            string startMessage = @"Welcome to the game “Minesweeper”. Try to reveal all cells without mines. Use   'top' to view the scoreboard, 'restart' to start a new game and 'exit' to quit  the game.";
            Console.WriteLine(startMessage + "\n");
        }
    }
}
