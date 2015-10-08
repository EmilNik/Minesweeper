namespace Minesweeper.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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
