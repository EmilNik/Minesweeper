using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Commands
{
    /// <summary>
    /// The exit command cares about closing the application when the command is executed.
    /// </summary>
    public class ExitCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("\nGood bye!\n");
            Environment.Exit(0);
        }
    }
}
