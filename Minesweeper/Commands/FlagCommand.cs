using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Commands
{
    public class FlagCommand : ICommand
    {
        private readonly Field field;

        private IValidator validator;

        private IPrinter printer;

        public FlagCommand(Field field, IValidator validator, IPrinter printer)
        {
            this.printer = printer;
            this.validator = validator;
            this.field = field;
        }
        public void Execute()
        {
            Console.Write("Enter row and column to flag: ");
            var lane = Console.ReadLine();
            if (!validator.IsMoveEntered(lane))
            {
                printer.PrintMessage(Messages.IllegalMove);
            }
            var row = int.Parse(lane.Split(' ')[0]);
            var col = int.Parse(lane.Split(' ')[1]);
            if (!this.field.IsMoveInBounds(row, col))
            {
                printer.PrintMessage(Messages.IllegalMove);
            }
            this.field.MineField[row, col].isFlagged = true;
        }
    }
}
