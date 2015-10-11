namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    using Minesweeper;
    using Minesweeper.Commands;

    public class MinesweeperEngine : IMinesweeperEngine
    {
        private ScoreBoard scoreBoard;

        private IPrinter printer;

        private IValidator validator;

        private Field field;

        private ICommandFactory commandFactory;

        private bool IsPlayerGrandWinner(Cell[,] matrix, int minesCount)
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
            this.printer = Printer.GetInstance(scoreBoard);
            this.validator = new Validator();
            var cel = new Cell();
            this.field = new Field(5, 10, 15);
            this.commandFactory = new CommandFactoryWithLazyLoading(printer, field, validator);

            field.Initialize();

            bool isBoomed = false;
            bool playerWon = false;

            printer.PrintMessage(Messages.StartMessage);

            while (true)
            {
                if (isBoomed || playerWon)
                {
                    field.Initialize();
                    isBoomed = false;
                }

                printer.PrintField(field.MineField, isBoomed);

                printer.PrintMessage(Messages.EnterRowColCommand);
                string line = Console.ReadLine();
                line = line.Trim();

                if (validator.IsMoveEntered(line))
                {
                    string[] inputParams = line.Split();
                    int row = int.Parse(inputParams[0]);
                    int col = int.Parse(inputParams[1]);

                    if (field.IsMoveInBounds(row, col) && !field.IsCellClickled(row, col))
                    {
                        isBoomed = field.MineField[row, col].isBomb;
                        playerWon = IsPlayerGrandWinner(field.MineField, field.NumberOfMines);

                        EndGame(isBoomed, playerWon);

                        field.RevialCell(row, col);
                    }
                    else
                    {
                        printer.PrintMessage(Messages.AlreadyOpenedOrOutOfRange);
                    }
                }
                else
                {
                    ICommand command = commandFactory.CreateCommand(line);

                    if (command != null)
                    {
                        command.Execute();
                    }
                }

            }
        }

        private void EndGame(bool isBoomed, bool playerWon)
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
            printer.PrintField(field.MineField, isBoomed);
            printer.PrintMessage(message, field.RevealedCells);
            string currentPlayerName = Console.ReadLine();
            scoreBoard.AddPlayer(currentPlayerName, field.RevealedCells);
        }
    }
}