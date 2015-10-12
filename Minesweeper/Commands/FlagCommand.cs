namespace Minesweeper.Commands
{
    using System;

    public class FlagCommand : ICommand
    {
        private readonly IField field;

        private IValidator validator;

        private IPrinter printer;

        public FlagCommand(IField field, IValidator validator, IPrinter printer)
        {
            this.printer = printer;
            this.validator = validator;
            this.field = field;
        }

        public void Execute()
        {
            Console.Write("Enter row and column to flag: ");
            var lane = Console.ReadLine();
            if (!this.validator.IsMoveEntered(lane))
            {
                this.printer.PrintMessage(Messages.IllegalMove);
            }

            var row = int.Parse(lane.Split(' ')[0]);
            var col = int.Parse(lane.Split(' ')[1]);
            if (!this.field.IsMoveInBounds(row, col))
            {
                this.printer.PrintMessage(Messages.IllegalMove);
            }

            this.field.MineField[row, col].IsFlagged = true;
        }
    }
}
