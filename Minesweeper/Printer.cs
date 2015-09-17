namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class Printer : IPrinter
    {
        public void PrintScoreBoard(IScoreBoard scoreBoard)
        {
            bool firstFive = false;
            int currentCounter = 1;

            Console.WriteLine();

            if (scoreBoard.scoreBoard.Values.Count == 0)
            {
                Console.WriteLine("Scoreboard empty!");
            }
            else
            {
                Console.WriteLine("Scoreboard:");

                foreach (int key in scoreBoard.Keys.OrderByDescending(obj => obj))
                {
                    foreach (string person in scoreBoard[key])
                    {
                        // TODO
                        if (currentCounter < 6)
                        {
                            Console.WriteLine("{0}. {1} --> {2} cells", currentCounter, person, key);
                            currentCounter++;
                        }
                        else
                        {
                            firstFive = true;
                            break;
                        }
                    }

                    if (firstFive)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
