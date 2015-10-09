namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    using Minesweeper;
    using Minesweeper.Commands;

    public class MinesweeperEngine
    {
        private ScoreBoard scoreBoard;

        private IPrinter printer;

        private IValidator validator;

        private Field field;

        private ICommandFactory commandFactory;

        private bool IsPlayerBoomed(string[,] matrix, int minesRow, int minesCol)
        {
            return matrix[minesRow, minesCol] == "*";
        }

        private bool DoPlayerWon(string[,] matrix, int minesCount)
        {
            bool isWinner = false;
            int counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((matrix[i, j] != "") && (matrix[i, j] != "*"))
                    {
                        counter++;
                    }
                }

            }
            if (counter == matrix.Length - minesCount)
            {
                isWinner = true;
            }
            return isWinner;
        }

        public void PlayMines()
        {
            this.scoreBoard = new ScoreBoard();
            this.printer = Printer.GetInstance(scoreBoard.scoreBoard);
            this.validator = new Validator();
            this.field = new Field(5, 10, 15);
            this.commandFactory = new CommandFactoryWithLazyLoading(printer, field);

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

                printer.PrintMessage(Messages.EnterRowCol);
                string line = Console.ReadLine();
                line = line.Trim();

                if (IsMoveEntered(line))
                {
                    string[] inputParams = line.Split();
                    int row = int.Parse(inputParams[0]);
                    int col = int.Parse(inputParams[1]);

                    if (field.IsMoveInBounds(row, col) && !field.IsCellClickled(row, col))
                    {
                        isBoomed = IsPlayerBoomed(field.MineField, row, col);
                        playerWon = DoPlayerWon(field.MineField, field.NumberOfMines);

                        EndGame(isBoomed, playerWon);

                        field.RevealNumber(row, col);
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


        /// <summary>
        /// Checks if user input is a valid move and returns a bool that is true if the move is valid and false if the move is not valid.
        /// </summary>
        /// <param name="line">User input as a string</param>
        /// <returns>Bool that is true if the move is valid and false if the move is not valid</returns>
        private bool IsMoveEntered(string line)
        {
            bool validMove = false;
            try
            {
                //TODO Validate wrong movements with the appropriate exception messages
                string[] inputParams = line.Split();
                int row = int.Parse(inputParams[0]);
                int col = int.Parse(inputParams[1]);
                validMove = true;
            }
            catch
            {
                validMove = false;
            }

            return validMove;
        }

    }
}