﻿namespace Minesweeper
{
    public static class Messages
    {
        public const string IllegalMove = "Illegal Move!";

        public const string StartMessage = @"Welcome to the game “Minesweeper”. 
                             Try to reveal all cells without mines. 
                             Use 'flag' to flag a cell that u think is a bomb,
                             Use 'top' to view the scoreboard,
                             Use 'restart' to start a new game 
                             Use 'exit' to quit  the game.";

        public const string EnterRowColCommand = "Enter row, column or command: ";

        public const string BoomMessage = "\nBooom! You are killed by a mine! \nYou revealed {0} cells without mines. \nPlease enter your name for the top scoreboard: ";

        public const string Success = "Congratulations! You are the WINNER!\nPlease enter your name for the top scoreboard: ";

        public const string AlreadyOpenedOrOutOfRange = "Cell already opened or is out of range of the minefield!";

        public const string InvalidCommand = "Invalid command!\n";

        public const string Bye = "Good bye!\n";
    }
}
