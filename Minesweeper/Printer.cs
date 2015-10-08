namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The class Printer cares about printing. It stores all kinds of strings that are to be printed and also prints given strings.
    /// </summary>
    public class Printer : IPrinter
    {
        private Dictionary<string, int> scoreBoard;

        public Printer(Dictionary<string, int> scoreBoard)
        {
            this.scoreBoard = scoreBoard;
        }
        /// <summary>
        /// Prints the highscores.
        /// </summary>
        /// <param name="scoreBoard">The scoreBoard that holds the highscores.</param>
        public void PrintScoreBoard()
        {
            var numberOfPrintedNames = 5;
            var items = from pair in this.scoreBoard
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

        /// <summary>
        /// Prints the field.
        /// </summary>
        /// <param name="minesMatrix">An array that holds information about each cell of the field.</param>
        /// <param name="boomed">A bool that hold information if the user has hit a mine.</param>
        public void PrintField(string[,] minesMatrix, bool boomed)
        {
            Console.WriteLine("\n     0 1 2 3 4 5 6 7 8 9");
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
                    else if (!(boomed) && (minesMatrix[i, j] != "") && (minesMatrix[i, j] != "*"))
                    {
                        Console.Write(" {0}", minesMatrix[i, j]);
                    }
                    else if ((boomed) && (minesMatrix[i, j] == ""))
                    {
                        Console.Write(" -");
                    }
                    else if ((boomed) && (minesMatrix[i, j] != ""))
                    {
                        Console.Write(" {0}", minesMatrix[i, j]);
                    }
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("   ---------------------");
        }

        /// <summary>
        /// Prints a given message without a new line after the end of the message.
        /// </summary>
        /// <param name="message">Message to be printed.</param>
        public void PrintMessage(string message)
        {
            Console.Write(message);
        }

        /// <summary>
        /// Prints a given message with a new line at the end.
        /// </summary>
        /// <param name="message">Message to be printed.</param>
        public void PrintMessageWithNewLine(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintMessage(string message, int openedCells)
        {
            Console.WriteLine(message, openedCells);
        }
    }
}
