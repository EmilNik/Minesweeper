using Minesweeper;
using Minesweeper.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

class Minichki
{
    private const int NumberOfMines = 15;
    private const int MinesFieldRows = 5;
    private const int MinesFieldCols = 10;


    private static bool Boom(string[,] matrix, int minesRow, int minesCol)
    {
        bool isKilled = false;
        int[] dRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
        int[] dCol = { 1, 0, -1, -1, -1, 0, 1, 1 };
        int minesCounter = 0;
        if (matrix[minesRow, minesCol] == "*")
        {
            isKilled = true;
        }
        if ((matrix[minesRow, minesCol] != "") && (matrix[minesRow, minesCol] != "*"))
        {
            Console.WriteLine("Illegal Move!");
        }
        if (matrix[minesRow, minesCol] == "")
        {
            for (int direction = 0; direction < 8; direction++)
            {
                int newRow = dRow[direction] + minesRow;
                int newCol = dCol[direction] + minesCol;
                if ((newRow >= 0) && (newRow < matrix.GetLength(0)) &&
                    (newCol >= 0) && (newCol < matrix.GetLength(1)) &&
                    (matrix[newRow, newCol] == "*"))
                {
                    minesCounter++;
                }
            }
            matrix[minesRow, minesCol] += Convert.ToString(minesCounter);
        }
        return isKilled;
    }
    private static bool DoPlayerWon(string[,] matrix, int cntMines)
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
        if (counter == matrix.Length - cntMines)
        {
            isWinner = true;
        }
        return isWinner;
    }
    private static void InitializeMinesField(out string[,] mines, out Random randomMines, out int row, out int col, out int minesCounter, out int revealedCellsCounter, out bool isBoomed, out bool playerWon)
    {

        randomMines = new Random();
        row = 0;
        col = 0;
        minesCounter = 0;
        revealedCellsCounter = 0;
        isBoomed = false;
        playerWon = false;

        mines = new string[MinesFieldRows, MinesFieldCols];

        for (int i = 0; i < mines.GetLength(0); i++)
        {
            for (int j = 0; j < mines.GetLength(1); j++)
            {
                mines[i, j] = "";
            }
        }
    }

   

    public void PlayMines()
    {
        Printer printer = new Printer();
        ScoreBoard scoreBoard = new ScoreBoard();
        ICommandFactory commandFactory = new CommandFactoryWithLazyLoading(scoreBoard);

        Random randomMines;
        string[,] minichki;
        int row;
        int col;
        int minesCounter;
        int revealedCellsCounter;
        bool isBoomed;
        bool playerWon;

        InitializeMinesField(out minichki, out randomMines, out row, out col, out minesCounter, out revealedCellsCounter, out isBoomed, out playerWon);

        FillWithRandomMines(minichki, randomMines);

        printer.PrintInitialMessage();

        while (true)
        {
            if (isBoomed || playerWon)
            {
                InitializeMinesField(out minichki, out randomMines, out row, out col, out minesCounter, out revealedCellsCounter, out isBoomed, out playerWon);

                FillWithRandomMines(minichki, randomMines);

            }
            printer.PrintField(minichki, isBoomed);

            Console.Write("Enter row and column: ");
            string line = Console.ReadLine();
            line = line.Trim();

            if (IsMoveEntered(line))
            {
                string[] inputParams = line.Split();
                row = int.Parse(inputParams[0]);
                col = int.Parse(inputParams[1]);

                if ((row >= 0) && (row < minichki.GetLength(0)) && (col >= 0) && (col < minichki.GetLength(1)))
                {
                    isBoomed = Boom(minichki, row, col);
                    if (isBoomed)
                    {

                        printer.PrintField(minichki, isBoomed);
                        Console.Write("\nBooom! You are killed by a mine! ");
                        Console.WriteLine("You revealed {0} cells without mines.", revealedCellsCounter);

                        Console.Write("Please enter your name for the top scoreboard: ");
                        string currentPlayerName = Console.ReadLine();
                        scoreBoard.AddPlayer(currentPlayerName, revealedCellsCounter);

                        Console.WriteLine();

                    }
                    playerWon = DoPlayerWon(minichki, minesCounter);
                    if (playerWon)
                    {
                        Console.WriteLine("Congratulations! You are the WINNER!\n");

                        Console.Write("Please enter your name for the top scoreboard: ");
                        string currentPlayerName = Console.ReadLine();
                        scoreBoard.AddPlayer(currentPlayerName, revealedCellsCounter);

                        Console.WriteLine();
                    }
                    revealedCellsCounter++;
                }
                else
                {
                    Console.WriteLine("Enter valid Row/Col!\n");
                }
            }
            else if (proverka(line))
            {
                ICommand command = commandFactory.CreateCommand(line);
            }
            else
            {
                Console.WriteLine("Invalid Command!");
            }
        }
    }
    private static bool proverka(string line)
    {
        if (line.Equals("top") || line.Equals("restart") || line.Equals("exit"))
        {
            return true;
        }
        else
            return false;
    }
    private static bool IsMoveEntered(string line)
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
    private static void FillWithRandomMines(string[,] mines, Random randomMines)
    {
        int minesCounter = 0;
        while (minesCounter < NumberOfMines)
        {
            int randomRow = randomMines.Next(0, 5);
            int randomCol = randomMines.Next(0, 10);
            if (mines[randomRow, randomCol] == "")
            {
                mines[randomRow, randomCol] += "*";
                minesCounter++;
            }
        }
    }
}
