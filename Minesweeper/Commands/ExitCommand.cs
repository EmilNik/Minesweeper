using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Commands
{
    public class ExitCommand : ICommand
    {
        private IPrinter printer;

        public ExitCommand(IPrinter printer)
        {
            this.printer = printer;
        }
        public void Execute()
        {

            this.printer.PrintMessage(Messages.Bye);
            Environment.Exit(0);
        }
    }
}
