namespace Minesweeper
{
    using System;
    using Commands;

    public class MinesweeperEngine : IMinesweeperEngine
    {
        private IScoreBoard scoreBoard;

        private IPrinter printer;

        private IValidator validator;

        private IField field;

        private ICommandFactory commandFactory;

        public bool IsPlayerGrandWinner(Cell[,] matrix, int minesCount)
        {
            bool isWinner = false;
            if (this.field.RevealedCells == matrix.Length - minesCount)
            {
                isWinner = true;
            }

            return isWinner;
        }

        public void PlayMines()
        {
            this.scoreBoard = new ScoreBoard(new TextFileDataManager());
            this.printer = Printer.GetInstance(this.scoreBoard);
            this.validator = new Validator();
            var cel = new Cell();
            this.field = new Field(5, 10, 15);
            this.commandFactory = new CommandFactoryWithLazyLoading(this.printer, this.field, this.validator);

            this.field.Initialize();

            bool isBoomed = false;
            bool playerWon = false;

            this.printer.PrintMessage(Messages.StartMessage);

            while (true)
            {
                if (isBoomed || playerWon)
                {
                    this.field.Initialize();
                    isBoomed = false;
                }

                this.printer.PrintField(this.field.MineField, isBoomed);

                this.printer.PrintMessage(Messages.EnterRowColCommand);
                string line = Console.ReadLine();
                line = line.Trim();

                if (this.validator.IsMoveEntered(line))
                {
                    string[] inputParams = line.Split();
                    int row = int.Parse(inputParams[0]);
                    int col = int.Parse(inputParams[1]);

                    if (this.field.IsMoveInBounds(row, col) && !this.field.IsCellClickled(row, col))
                    {
                        isBoomed = this.field.MineField[row, col].IsBomb;
                        playerWon = this.IsPlayerGrandWinner(this.field.MineField, this.field.NumberOfMines);

                        this.EndGame(isBoomed, playerWon);

                        this.field.RevialCell(row, col);
                    }
                    else
                    {
                        this.printer.PrintMessage(Messages.AlreadyOpenedOrOutOfRange);
                    }
                }
                else
                {
                    ICommand command = this.commandFactory.CreateCommand(line);

                    if (command != null)
                    {
                        command.Execute();
                    }
                }
            }
        }

        public void EndGame(bool isBoomed, bool playerWon)
        {
            string message;

            if (playerWon)
            {
                message = Messages.Success;
            }
            else if (isBoomed)
            {
                message = Messages.BoomMessage;
            }
            else
            {
                return;
            }

            this.printer.PrintField(this.field.MineField, isBoomed);
            this.printer.PrintMessage(message, this.field.RevealedCells);
            string currentPlayerName = Console.ReadLine();
            this.scoreBoard.AddPlayer(currentPlayerName, this.field.RevealedCells);
        }
    }
}