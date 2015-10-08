namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class Messages
    {
        public const string IligalMove = "Illegal Move!";

        public const string StartMessage = @"Welcome to the game “Minesweeper”. 
                               Try to reveal all cells without mines. 
                               Use   'top' to view the scoreboard,
                               Use 'restart' to start a new game 
                               Use 'exit' to quit  the game.";

        public const string EnterRowCol = "Enter row and column: ";

        //TODO :D
        public const string BoomMessage = "\nBooom! You are killed by a mine! \nYou revealed {0} cells without mines.\nPlease enter your name for the top scoreboard: ";

        public const string Success = "Congratulations! You are the WINNER!\nPlease enter your name for the top scoreboard: ";

        public const string AlreadyOpenedOrOutOfRange = "Cell already opened or is out of range of the minefield!";

        public const string InvalidCommand = "Invalid command!\n";

        public const string Bye = "Good bye!\n";
    }
}
