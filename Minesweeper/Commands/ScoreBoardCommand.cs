namespace Minesweeper.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The exit command cares about printing the scoreBoard when the command is executed.
    /// </summary>
    public class ScoreBoardCommand : ICommand
    {
        private IPrinter printer;

        public ScoreBoardCommand(IPrinter printer)
        {
            this.printer = printer;
        }

        public void Execute()
        {
            this.printer.PrintScoreBoard();
        }
    }
}
