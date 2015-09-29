using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Commands
{
    public class ExitCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("\nGood bye!\n");
            Environment.Exit(0);
        }
    }
}
