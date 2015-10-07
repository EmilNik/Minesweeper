using Minesweeper;
using Minesweeper.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

public class Minichki
{
    private bool IsPlayerBoomed(string[,] matrix, int minesRow, int minesCol)
    {
        return matrix[minesRow, minesCol] == "*";
    }

    private  bool DoPlayerWon(string[,] matrix, int minesCount)
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
        ScoreBoard scoreBoard = new ScoreBoard();
        Printer printer = new Printer();
        ICommandFactory commandFactory = new CommandFactoryWithLazyLoading(scoreBoard, printer);
        IValidator validator = new Validator();
        Field field = new Field(5, 10, 15);

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
                    if (isBoomed)
                    {
                        printer.PrintField(field.MineField, isBoomed);
                        printer.PrintMessage("\nBooom! You are killed by a mine! \nYou revealed {field.RevialedCells} cells without mines.\nPlease enter your name for the top scoreboard: ");
                        string currentPlayerName = Console.ReadLine();
                        scoreBoard.AddPlayer(currentPlayerName, field.RevealedCells);

                        Console.WriteLine();
                    }

                    field.RevealNumber(row, col);

                    playerWon = DoPlayerWon(field.MineField, field.NumberOfMines);
                    if (playerWon)
                    {
                        printer.PrintField(field.MineField, isBoomed);
                        printer.PrintMessage(Messages.Success);
                        string currentPlayerName = Console.ReadLine();
                        scoreBoard.AddPlayer(currentPlayerName, field.RevealedCells);
                    }
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

    private  bool IsMoveEntered(string line)
    {
        bool validMove = false;
        try
        {
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