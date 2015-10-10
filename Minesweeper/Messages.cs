namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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

        public const string BoomMessage =  Environment.NewLine + 
            "Booom! You are killed by a mine!" + Environment.NewLine +  
            "You revealed {0} cells without mines." + Environment.NewLine + 
            "Please enter your name for the top scoreboard: ";

        public const string Success = "Congratulations! You are the WINNER!" + Environment.NewLine + 
            "Please enter your name for the top scoreboard: ";

        public const string AlreadyOpenedOrOutOfRange = "Cell already opened or is out of range of the minefield!";

        public const string InvalidCommand = "Invalid command!" + Environment.NewLine;

        public const string Bye = "Good bye!" + Environment.NewLine;
    }
}
