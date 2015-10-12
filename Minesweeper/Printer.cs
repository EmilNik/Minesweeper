namespace Minesweeper
{
    using System;
    using System.Linq;

    /// <summary>
    /// The class Printer cares about printing. It stores all kinds of strings that are to be printed and also prints given strings.
    /// </summary>
    public class Printer : IPrinter
    {
        // Singleton
        private static Printer instance;

        private readonly IScoreBoard scoreBoard;    

        private Printer(IScoreBoard scoreBoard)
        {
            this.scoreBoard = scoreBoard;
        }

        public static Printer GetInstance(IScoreBoard scoreBoard)
        {
            // No need for multi threading fix.
            if (instance == null)
            {
                instance = new Printer(scoreBoard);
            }

            return instance;
        }

        /// <summary>
        /// Prints the highscores.
        /// </summary>
        /// <param name="scoreBoard">The scoreBoard that holds the highscores.</param>
        /// 
        public void PrintScoreBoard()
        {
            var numberOfPrintedNames = 10;
            var items = from pair in this.scoreBoard.Scores
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

                var message = "{0}. {1} --> {2} cell";

                if (key != 1)
                {
                    message += "s";
                }

                Console.WriteLine(message, i + 1, person, key);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Prints the field.
        /// </summary>
        /// <param name="minesMatrix">An array that holds information about each cell of the field.</param>
        /// <param name="boomed">A bool that hold information if the user has hit a mine.</param>
        public void PrintField(Cell[,] minesMatrix, bool boomed)
        {
            Console.WriteLine("\n     0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < minesMatrix.GetLength(0); i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < minesMatrix.GetLength(1); j++)
                {
                    if (!boomed)
                    {
                        ////TODO implement flaged cell color
                        if (minesMatrix[i, j].Value == string.Empty ||
                            minesMatrix[i, j].IsBomb)
                        {
                            if (minesMatrix[i, j].IsFlagged)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }

                            Console.Write(" ?");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.Write(" {0}", minesMatrix[i, j].Value);
                        }
                    }
                    else
                    {
                        if (minesMatrix[i, j].Value == string.Empty)
                        {
                            Console.Write(" -");
                        }
                        else
                        {
                            Console.Write(" {0}", minesMatrix[i, j].Value);
                        }
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

        public void PrintMessage(string message, int openedCells)
        {
            Console.Write(message, openedCells);
        }

        /// <summary>
        /// Prints a given message with a new line at the end.
        /// </summary>
        /// <param name="message">Message to be printed.</param>
        public void PrintMessageWithNewLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
