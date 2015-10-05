using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class Printer : IPrinter
    {
        public void PrintScoreBoard(ScoreBoard scoreBoard)
        {
            var numberOfPrintedNames = 5;
            var items = from pair in scoreBoard.scoreBoard
                        orderby pair.Value descending
                        select pair;

            var keys = items.ToArray();

            if (keys.Count() < numberOfPrintedNames)
            {
                numberOfPrintedNames = keys.Count();
            }

            for (int i = 0; i < numberOfPrintedNames; i++)
            {
                var person = keys[i].Key;
                var key = keys[i].Value;

                var message = $"{i+1}. {person} --> {key} cell";

                if (key != 1)
                {
                    message += "s";
                }

                Console.WriteLine(message);
            }

            Console.WriteLine();
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
            string startMessage = @"Welcome to the game “Minesweeper”.
Try to reveal all cells without mines. 
Use 'top' to view the scoreboard, 
    'restart' to start a new game and 
    'exit' to quit  the game.";
            PrintMessageWithNewLine(startMessage + "\n");
        }

        public void PrintMessageWithNewLine(string message)
        {
            Console.WriteLine(message+ "\n");
        }

        public void PrintMessage(string message)
        {
            Console.Write(message);
        }
    }
}
